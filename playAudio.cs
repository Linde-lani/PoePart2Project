namespace PoePart1
{
    using System.Media;
    using System;
    using System.IO;

    public class playAudio
    {
        public playAudio()
        {
            //This retieves the location where the app is running
            string projectLocation = AppDomain.CurrentDomain.BaseDirectory;

            //Displays the project location
            Console.WriteLine(projectLocation);

            //The code will be updated the "bin\\Debug\\" into an empty string
            string updatedPath = projectLocation.Replace("bin\\Debug\\", "");

            //The path to the audio is constructed
            //The complete path string is stored in this string
            string fullPath = Path.Combine(updatedPath, "Greeting.wav");

            //The method is called to play the audio
            playWav(fullPath);
        }

        // method to play audio
        private void playWav(string fullPath)
        {
            //Checks if the audio is in the fullpath location
            try
            {
                //To play the sound that is in the fullPath location
                //Soundplayer controls playback of sound
                using (SoundPlayer player = new SoundPlayer(fullPath))
                {
                    //The method will wait until the playback is complete before going forward
                    player.PlaySync();
                }

            }
            catch (Exception error)
            {
                //Outputs error message
                Console.WriteLine(error.Message);

            }


        }

    }
}