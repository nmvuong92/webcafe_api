using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateFileAttribute : RequiredAttribute
    {
        protected override ValidationResult IsValid(object value,
     ValidationContext validationContext)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;

            // The file is required.
            if (file == null)
            {
                return new ValidationResult("Please upload a file!");
            }

            // The meximum allowed file size is 10MB.
            if (file.ContentLength > 5 * 1024 * 1024)
            {
                return new ValidationResult("This file is too big (5mb maximum)!");
            }

            // Only PDF can be uploaded.
            string ext = Path.GetExtension(file.FileName);
            if (String.IsNullOrEmpty(ext) || !(new string[] { ".pdf", ".doc",".docx",".png",".gif",".jpg","jpeg" }).Contains(ext,StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult("This file is not a .pdf, .doc,.docx,.png,.gif,.jpg,jpeg!");
            }

            // Everything OK.
            return ValidationResult.Success;
        }
    }
}