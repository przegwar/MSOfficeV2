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
using System.Collections.Generic;

namespace G1ANT.Addon.MSOfficeV2
{
    [Command(Name = "excel.runmacro", Tooltip = "Run macro in currently active excel instance.")]
    public class ExcelRunMacroCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Name of macro that is defined in a workbook")]
            public TextStructure Name { get; set; }

            [Argument(Tooltip = "Comma separated arguments that will be passed to macro")]
            public ListStructure Args { get; set; }

            [Argument]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public ExcelRunMacroCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                List<object> args = new List<object>();

                if (arguments.Args?.Value != null)
                {
                    foreach (Structure arg in arguments.Args?.Value)
                    {
                        TextStructure tmpArgument = arg as TextStructure;
                        if (tmpArgument != null)
                        {
                            args.Add(tmpArgument.Value);
                        }
                    }
                }
                //else
                //{
                //    args.Add(string.Empty);
                //}

                ExcelManager.CurrentExcel.RunMacro(arguments.Name.Value, args);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Problem occured while running excel macro. Path: '{arguments.Name.Value}', Arguments count: '{arguments.Args?.Value?.Count ?? 0}'", ex);
            }
        }
    }
}
