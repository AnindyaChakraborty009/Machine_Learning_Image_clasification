using System;
using System.IO;
using System.Windows.Forms;
using Machine_Learning_Image_clasification;

namespace ConAppImagePredictRec
{
    internal class Program
    {
        [STAThread] // Required for using OpenFileDialog
        static void Main(string[] args)
        {
            Console.WriteLine("Image Classification Application");

            // Configure the OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image File",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Multiselect = false // Allow selecting only one file
            };

            // Show the dialog and get the selected file
            string selectedFilePath = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;

                // Validate the file path
                if (File.Exists(selectedFilePath))
                {
                    try
                    {
                        // Read the selected image
                        var imageBytes = File.ReadAllBytes(selectedFilePath);
                        MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
                        {
                            ImageSource = imageBytes,
                        };

                        // Load model and predict output
                        var result = MLModel1.Predict(sampleData);
                        Console.WriteLine($"Predicted Label: {result.PredictedLabel}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("The file does not exist. Please check the path and try again.");
                }
            }
            else
            {
                Console.WriteLine("No file was selected.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
