# Readme

Example of how to get DocFx to document a 'project' (for a customer) which contains multiple solutions (e.g. a collection of micro services), and have a single release notes for the all the microservices combined (assuming you release / version all the components together).

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

For writing out to .pdf, just [follow the walkthrough](https://dotnet.github.io/docfx/tutorial/walkthrough/walkthrough_generate_pdf.html). Install the prerequisites first!

Pdfs get written to the '''\docfx_project\_site_pdf''' folder.

## Missing steps

Running the power shell script obviously should be done as a final stage in Bamboo / Jenkins. The process should be:

* Build all your visual studio solutions.
* Unit test them.
* Run DocFx via powershell script.
* Copy the output somewhere, e.g. host on Apache. 
