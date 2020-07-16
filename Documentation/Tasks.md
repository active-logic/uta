# Howl related tasks

# Storing the library online

Likely, the library is stored in a repository. A unity project used to edit and validate the library is stored in another Unity project. Let's start from here.
Having a look at the goap project suggests the correct structure:

```
- Root directory (not in source control)
--- Workspace (unity project, in gitlab)
--- UPM library (usually stored on github)
```

I moved some files around. Before anything let's ensure everything is under source control.

Now let's fix the workspace so the tests can run

## Pending tasks

*Configuring the conversion*
At the moment what we need is a configuration file one level above Assets; we can then edit this manually or via the Howl window.

What is configurable?
- The modifiers, which can be cangjie or dingbats

*Hinted import*
Hinted import is a per project setting; there is also a language and platform level. It would be okay for a project to disable platform/language hints

*Escape string literals*
String literals should not be converted

*Viewing mode*
Initially the default should be viewing mode. Viewing mode means that nothing is ever modified
