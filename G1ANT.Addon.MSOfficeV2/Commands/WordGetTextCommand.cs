/**
* Copyright(C) G1ANT Ltd, All rights reserved
* Solution G1ANT.Addon.MSOfficeV2, Project G1ANT.Addon.MSOfficeV2
* www.g1ant.com
*
* Licensed under the G1ANT license.
* See License.txt file in the project root for full license information.
*/

using G1ANT.Language;
using System;

namespace G1ANT.Addon.MSOfficeV2
{
    [Command(Name = "word.gettext", Tooltip = "This command gets all text from current document.", NeedsDelay = true, IsUnderConstruction = false)]

    public class WordGetTextCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument]
            public VariableStructure Result { get; set; } = new VariableStructure("result");

        }
        public WordGetTextCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            WordWrapper wordWrapper = WordManager.CurrentWord;

            try
            {
                string val = wordWrapper.GetText();
                Scripter.Variables.SetVariableValue(arguments.Result.Value, new Language.TextStructure(val));
            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Error occured while trying get text. Message: {ex.Message}", ex);

            }
        }
    }
}
