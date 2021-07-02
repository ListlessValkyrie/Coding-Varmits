# Readme

## DocFx setup

See the [getting started guide](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html).

* Created a sampled project: ```doxfx init -q```
* Copied this to ```.\MultiSolution"```

The ```docfx.bat``` file will now build this.

Edited docfx.json within ```docfx_project``` so that:

```
"src": [
  {
    "src": "../",
    "files": [ "FooProjectA/**.csproj", "FooProjectB/**.csproj" ]
  }
],
```

points to the project solutions.

if you run the powershell script (docfx.ps1) you can build and then host this on [localhost](http:localhost:8080).
