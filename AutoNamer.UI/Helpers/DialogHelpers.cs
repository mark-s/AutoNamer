using System.Windows.Forms;

namespace AutoNamer.UI.Helpers
{
    public class DialogHelpers : IDialogHelpers
    {

        public string GetFolderChoice()
        {
            var chosenFolder = "";

            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.ShowNewFolderButton = false;
                folderDialog.Description = "Please select a folder containing the ePubs to Rename";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                    chosenFolder = folderDialog.SelectedPath;
            }

            return chosenFolder;
        }
        


    }


}
