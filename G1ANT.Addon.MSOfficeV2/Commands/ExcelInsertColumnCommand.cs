/**
* Copyright(C) G1ANT Ltd, All rights reserved
* Solution G1ANT.Addon.MSOfficeV2, Project G1ANT.Addon.MSOfficeV2
* www.g1ant.com
*
* Licensed under the G1ANT license.
* See License.txt file in the project root for full license information.
*/

using System;

using G1ANT.Language;



namespace G1ANT.Addon.MSOfficeV2
{
    [Command(Name = "excel.insertcolumn", Tooltip = "Inserts empty column.")]
    public class ExcelInsertColumnCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Tooltip = "Cell's column index")]
            public IntegerStructure ColIndex { get; set; }

            [Argument(Tooltip = "Cell's column name")]
            public TextStructure ColName { get; set; }

            [Argument(Tooltip = "Determines, whether to insert column 'before' or 'after' specified column. By default: 'after'")]
            public TextStructure Where { get; set; } = new TextStructure("after");
        }
        public ExcelInsertColumnCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            object col = null;
            try
            {
                if (arguments.ColIndex != null)
                    col = arguments.ColIndex.Value;
                else if (arguments.ColName != null)
                    col = arguments.ColName.Value;
                else
                    throw new ArgumentException("One of the ColIndex or ColName arguments have to be set up.");
                ExcelManager.CurrentExcel.InsertColumn(col, arguments.Where.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while trying to insert column. Column: '{col}', where: '{arguments.Where.Value}'. Message: {ex.Message}", ex);
            }            
        }
    }
}
