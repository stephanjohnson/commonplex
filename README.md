# commonplex
CommonPlex is forked from WikiPlex (wikiplex.codeplex.com) and is an extensible implementation of CommonMark.  
This project has its roots in a requirement to use CommonMark markdown syntax for a project, but also to be able to extend the renderer beyond what the specification allows. For example implementation of tables which is not supported by the specification and has no plans to implement.  
None of the C# renderers supported any form of extending the rendering engine to allow simple additional syntax macros.  
Based on past experience with the wiki renderer for the CodePlex site (WikiPlex) which has a suberb extensibility story, I have decided to fork this project to Github, remove all of the wiki syntax macros and start from scratch to implement CommonMark syntax.  

## Usage
Using this engine is very simple:  
```
new CommonPlex.RenderEngine().Render("this is **bold** and *italic* rendered HTML from markdown");
```
## Extensibility
more on this topic later.
