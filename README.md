MSBuild Text Replacement Task
=======================================

## Introduction ##

A MSBuild task to allow replacement of a string in a file with another value.

## Usage ##

Include the DLL in your MSBuild project

	<UsingTask TaskName="TextReplacementTask" AssemblyFile="..\PATH-TO-DLL\RhysG.MSBuild.Common.dll"/>

Then call the *TextReplacementTask* this takes several parameters described below. To replace all instances of the string *$placeholder$* with
*Replacement Text*:

	<TextReplacementTask File="..\PATH-TO-FILE\SourceFile.js" OutputFile="..\PATH-TO-FILE\OutputFile.js" StringToReplace="$placeholder$" Value="Replacement Text" />

### Parameters ###

<table>
	<tr>
		<th>Parameter</th>
		<th>Description</th>
	</tr>
	<tr>
		<td>File</td>
		<td>The path to the source file</td>
	</tr>
	<tr>
		<td>OutputFile</td>
		<td>The path to the output file</td>
	</tr>
	<tr>
		<td>StringToReplace</td>
		<td>The text to find in the source file</td>
	</tr>
	<tr>
		<td>Value</td>
		<td>The text to replace all occurences of <em>StringToReplace</em></td>
	</tr>
</table>

## License ##

This library is released under the *FreeBSD License*, see **LICENSE.txt** for more information.

Blog: http://www.rhysgodfrey.co.uk

Twitter: @rhysgodfrey