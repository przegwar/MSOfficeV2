# word.replace

**Syntax:**

```G1ANT
word.replace  from ‴‴  to ‴‴

```

**Description:**

Command `word.replace` allows to replace any word in document. 

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`from`| "string":{TOPIC-LINK+string}| yes |  |word to be found in document|
|`to`| "string":{TOPIC-LINK+string} | yes |  | word to be replaced in document|
|`matchcase`| "bool":{TOPIC-LINK+boolean} | no |false | if set to true, then case sensitive|
|`wholewords`| "bool":{TOPIC-LINK+boolean} | no | false | If set to false, replaces given search even in substrings|
|`if`| "bool":{TOPIC-LINK+boolean}| no | true | runs the command only if condition is true |
|`timeout`| "variable":{TOPIC-LINK+variable}| no | "♥timeoutcommand":{TOPIC-LINK+special-variables} | specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorjump` | "label":{TOPIC-LINK+label}| no | | name of the label to jump to if given `timeout` expires |
|`errormessage`| "string":{TOPIC-LINK+string}| no |  | message that will be shown in case error occurs and no `errorjump` argument is specified |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit "Common Arguments":{TOPIC-LINK+common-arguments} manual page.

This command is contained in **G1ANT.Addon.MSOffice.dll**.
See: "https://github.com/G1ANT-Robot/G1ANT.Addon.MSOffice":https://github.com/G1ANT-Robot/G1ANT.Addon.MSOffice

**Example 1**:

```G1ANT
♥toInsert = ‴I hate yogurt. It's just stuff with bits in. All I've got to do is pass as an ordinary human being. Simple. What could possibly go wrong? Saving the world with meals on wheels.‴
word.open path ‴C:\test\Random.docx‴ result ♥wordHandleTest
word.inserttext text ♥toInsert replacealltext true
word.replace from ‴Saving‴ to ‴Killing‴ matchcase false wholewords true

```

The example above shows how to open word document, insert text to it and replace a word in the text. We firstly create a variable ♥toInsert where we store the text that we want to insert later. Then we open word using `word.open` command. `word.replace` allows us to change the word "saving" to "killing".

!{IMAGE-LINK+2017-11-17-word-replace}!