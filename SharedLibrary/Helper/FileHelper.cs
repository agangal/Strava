using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Helper
{
    using System.Threading.Tasks;
    using Windows.Storage;
    using System.Diagnostics;
    public class FileHelper
    {
        public async Task<string> ReadFile(string filename)
        {
          
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localFolder = applicationData.LocalFolder;
            string response = null;
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync(filename);
                response = await FileIO.ReadTextAsync(sampleFile);
            }
            catch (Exception e)
            {
                Debug.WriteLine("In read file : " + e);              
            }
            return response;
        }

        public async Task<bool> writeFile(string filename, string response)
        {
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localFolder = applicationData.LocalFolder;
            Debug.WriteLine("In writeFile : " + filename);
            try
            {
                //Debug.WriteLine("In try of write.");
                StorageFile sampleFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(sampleFile, response);
            }
            catch (System.UnauthorizedAccessException e)
            {
                Debug.WriteLine("in write to file : " + filename + " : " + e);                
                return false;
            }
            return true;
        }
    }
}
