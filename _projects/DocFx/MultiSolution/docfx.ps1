# DocFx build script.

Write-Output "What you wanna do?"

Write-Output "0: Rebuild"
Write-Output "1: Localhost on 8080"

do {
  write-host -nonewline "Enter value: "
  $inputString = read-host
  $value = $inputString -as [Int]
  $ok = $value -ne $NULL
  if ( -not $ok ) { write-host "You must enter an integer value" }
}
until ( $ok )

switch ($value)
{
	0 {	.\lib\docfx\docfx.exe .\docfx_project\docfx.json }
	1 { .\lib\docfx\docfx .\docfx_project\docfx.json --serve }	
}