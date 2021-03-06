#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.IO;
using Syncfusion.Presentation;

namespace blazor_samples.Data.FileFormats.Presentation
{
    public class WriteProtectionService
    {
        string basePath = @"wwwroot/Presentation/";
        /// <summary>
        /// Create a write protection Presentation document
        /// </summary>
        /// <returns>Return the created Presentation document as stream</returns>
        public MemoryStream CreateWriteProtectionPresentation(string Password)
        {
            //Open the existing presentation            
            FileStream fileStreamInput = new FileStream(basePath + "Transition.pptx", FileMode.Open, FileAccess.Read);
            //Open a existing PowerPoint presentation.
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStreamInput);

            if (Password == null)
                Password = string.Empty;

            //Set the write protection for presentation instance
            presentation.SetWriteProtection(Password);

            //Save the document as a stream and retrun the stream
            using (MemoryStream stream = new MemoryStream())
            {
                //Save the created PowerPoint document to MemoryStream
                presentation.Save(stream);
                return stream;
            }
        }        
    }
}