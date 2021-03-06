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
    [Command(Name = "word.inserttext", Tooltip = "This command inserts text into current document.", NeedsDelay = true, IsUnderConstruction = false)]

    public class WordInsertTextCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "text to be placed into document")]
            public TextStructure Text { get; set; } = new TextStructure(string.Empty);
            [Argument]
            public BooleanStructure ReplaceAllText { get; set; } = new BooleanStructure(false);

        }
        public WordInsertTextCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            WordWrapper wordWrapper = WordManager.CurrentWord;
            string text = arguments.Text.Value;
            bool replaceAlltext = arguments.ReplaceAllText.Value;

            try
            {
                wordWrapper.InsertText(text, replaceAlltext);
            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Error occured while trying to insert text. Text: '{arguments.Text.Value}'. Message: {ex.Message}", ex);

            }
        }
    }
}
