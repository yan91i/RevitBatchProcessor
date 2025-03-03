﻿//
// Revit Batch Processor
//
// Copyright (c) 2020  Daniel Rumery, BVN
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//

using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BatchRvtUtil;

namespace BatchRvtGUI;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (!RevitVersion.GetInstalledRevitVersions().Any())
        {
            var errorMessage = new StringBuilder();
            errorMessage.AppendLine(
                "ERROR: Could not detect the BatchRvt addin for any version of Revit installed on this machine!");
            errorMessage.AppendLine();
            errorMessage.AppendLine("You must first install the BatchRvt addin for at least one version of Revit.");

            BatchRvtGuiForm.ShowErrorMessageBox(errorMessage.ToString());
        }
        else
        {
            Application.Run(new BatchRvtGuiForm());
        }
    }
}