using System.IO;
using System;
using System.Drawing;

namespace PoePart1
{
    public class aiLogo
    {
        public aiLogo()
        {

            //get full location of where the app is running
            string fullLocation = AppDomain.CurrentDomain.BaseDirectory;

            //Replacing the bin\\Debug path
            string newLocation = fullLocation.Replace("bin\\Debug", "");

            //Then combine the path to display the image
            string fullPath = Path.Combine(newLocation, "ailogo.png");

            //Using the ascii art

            //Creating the Bitmap object using the fullPath of the image
            Bitmap image = new Bitmap(fullPath);

            //Adjusting the size of the bitmap
            image = new Bitmap(image, new Size(100, 50));

            //outer and inner loop to iterate the pixels the bitmap
            for (int height = 0; height < image.Height; height++)
            {

                for (int width = 0; width < image.Width; width++)
                {
                    //This gets the color of the pixel and turns it gray
                    Color pixelColor = image.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    //This are the characters that will be used to produce the ascii art
                    char asciiChar = gray > 200 ? '.' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 50 ? '#' : '@';
                    //Display of the ascii art
                    Console.Write(asciiChar);

                }//End of inner loop
                //This is to skip the line
                Console.WriteLine();

            }//End of outer loop
        }//End of constructor

    }//End of class

}//End of namespace