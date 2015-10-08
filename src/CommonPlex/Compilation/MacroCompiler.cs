using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using CommonPlex.Common;
using CommonPlex.Compilation.Macros;

namespace CommonPlex.Compilation
{
    /// <summary>
    /// Handles compiling and caching a <see cref="IMacro"/>. Compilation includes normalizing all rules into a single regular expression.
    /// </summary>
    public class MacroCompiler
    {
        private static readonly Regex numberOfCapturesRegex = new Regex(@"(?x)(?<!\\)\((?!\?)");
        private readonly Dictionary<string, CompiledMacro> compiledMacros;
        private readonly ReaderWriterLockSlim compileLock;

        /// <summary>
        /// Initializes a new instance of the <see cref="MacroCompiler"/> class.
        /// </summary>
        public MacroCompiler()
        {
            compiledMacros = new Dictionary<string, CompiledMacro>();
            compileLock = new ReaderWriterLockSlim();
        }

        /// <summary>
        /// Will compile a new <see cref="IMacro"/> or return a previously cached <see cref="CompiledMacro"/>.
        /// </summary>
        /// <param name="macro">The macro to compile.</param>
        /// <returns>The compiled macro.</returns>
        public virtual CompiledMacro Compile(IMacro macro)
        {
            Guard.NotNull(macro, "macro");
            Guard.NotNullOrEmpty(macro.Id, "macro", "The macro identifier must not be null or empty.");

            try
            {
                // for performance sake, 
                // we'll initially use only a read lock
                compileLock.EnterReadLock();
                CompiledMacro compiledMacro;
                if (compiledMacros.TryGetValue(macro.Id, out compiledMacro))
                    return compiledMacro;
            }
            finally
            {
                compileLock.ExitReadLock();
            }

            // this is assuming the compiled macro was not found
            // and will attempt to compile it.
            compileLock.EnterUpgradeableReadLock();
            try
            {
                if (compiledMacros.ContainsKey(macro.Id))
                    return compiledMacros[macro.Id];

                compileLock.EnterWriteLock();
                try
                {
                    if (compiledMacros.ContainsKey(macro.Id))
                        return compiledMacros[macro.Id];

                    Guard.NotNullOrEmpty(macro.Rules, "macro", "The macro rules must not be null or empty.");

                    CompiledMacro compiledMacro = CompileMacro(macro);
                    compiledMacros[macro.Id] = compiledMacro;
                    return compiledMacro;
                }
                finally
                {
                    compileLock.ExitWriteLock();
                }
            }
            finally
            {
                compileLock.ExitUpgradeableReadLock();
            }
        }

        private static CompiledMacro CompileMacro(IMacro macro)
        {
            Regex regex;
            IList<string> captures;

            CompileRules(macro.Rules, out regex, out captures);

            return new CompiledMacro(macro.Id, regex, captures);
        }

        private static void CompileRules(IList<MacroRule> rules, out Regex regex, out IList<string> captures)
        {
            var regexBuilder = new StringBuilder();
            captures = new List<string>();

            regexBuilder.AppendLine("(?x)");
            captures.Add(null);

            for (int i = 0; i < rules.Count; i++)
                CompileRule(rules[i], regexBuilder, captures, i == 0);

            regex = new Regex(regexBuilder.ToString());
        }

        private static void CompileRule(MacroRule rule, StringBuilder regex, IList<string> captures, bool isFirstRule)
        {
            if (!isFirstRule)
            {
                regex.AppendLine();
                regex.AppendLine();
                regex.AppendLine("|");
                regex.AppendLine();
            }

            regex.AppendFormat("(?-xis)(?m)({0})(?x)", rule.Regex);

            int numberOfCaptures = GetNumberOfCaptures(rule.Regex);

            for (int i = 0; i <= numberOfCaptures; i++)
            {
                string scope = null;

                foreach (int captureIndex in rule.Captures.Keys)
                {
                    if (i == captureIndex)
                    {
                        scope = rule.Captures[captureIndex];
                        break;
                    }
                }

                captures.Add(scope);
            }
        }

        private static int GetNumberOfCaptures(string regex)
        {
            return numberOfCapturesRegex.Matches(regex).Count;
        }

        ///<summary>
        /// This will flush all compiled macros from the cache.
        ///</summary>
        /// <remarks>It is not recommended to use this method as compilation of macros is an expensive operation.</remarks>
        public void Flush()
        {
            compileLock.EnterWriteLock();
            try
            {
                compiledMacros.Clear();
            }
            finally
            {
                compileLock.ExitWriteLock();
            }
        }
    }
}