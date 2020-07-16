# Howl related tasks

# Integration mode

This is a flag that specifies what the Unity integration does.
Why is this wanted? Initially I'm not going to do anything, I just want to look around.

# Storing the library online

Likely, the library is stored in a repository. A unity project used to edit and validate the library is stored in another Unity project. Let's start from here.
Having a look at the goap project suggests the correct structure:

```
- Root directory (not in source control)
--- Workspace (unity project, in gitlab)
--- UPM library (usually stored on github)
```

I moved some files around. Before anything let's ensure everything is under source control.

Now let's fix the workspace so the tests can run... ?

Not by a long shot.
Tests cannot run unless the package is embedded. So I need an "empty shell" project which is also not in VCS (or if not so empty, ignores the package repo)

## Pending tasks

*Configuring the conversion*
At the moment what we need is a configuration file one level above Assets; we can then edit this manually or via the Howl window.

What is configurable?
- We want to specify conversion by related groups

*Hinted import*
Hinted import is a per project setting; there is also a language and platform level. It would be okay for a project to disable platform/language hints

*Escape string literals*
String literals should not be converted

*Collapse space before sub/superscripts*
