using BlazorApp_Nouveaute.Models.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp_Nouveaute.Client.Pages
{
    public class MyFormulaireBase : ComponentBase
    {

        #region properties properties view
        protected DemoModel Demo = new();
        protected string? FileContent { get; set; }
        protected IBrowserFile? SelectedFile { get; set; }
        private IReadOnlyList<IBrowserFile> _browserFiles = [];
        #endregion


        #region method protected view

        protected async Task OnFileChanged(InputFileChangeEventArgs args)
        {
            //var files = args.GetMultipleFiles(2);
            //SelectedFile = args.File;

            //if (args.GetMultipleFiles().Count <= 2) {
            _browserFiles = args.GetMultipleFiles();
                
            //}
            
            
            //await ReadFileContentAsync(args.File);
        }


        protected async Task OnSubmitAsync()
        {
            if (SelectedFile is not null)
            {
                await ReadFileContentAsync(SelectedFile);
            }
            else if (_browserFiles.Count>0)
            {
                foreach(var file in _browserFiles)
                {
                    await ReadFileContentAsync(file);
                }
            }
        }

        #endregion

        #region private method 
        /// <summary>
        /// Lit le InputFileChangedEventsARgs, récupère le fichier est l'affiche
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task ReadFileContentAsync(IBrowserFile File) 
        { 
            var maxSize = 10 * 1024 * 1024; // -- max 10 Mo
            using var filestream = File.OpenReadStream(maxSize);
            using var reader = new StreamReader(filestream);

            FileContent += await reader.ReadToEndAsync() + "\n";
            await this.InvokeAsync(StateHasChanged);
        }
        #endregion
    }
}
