using System;
using System.Windows.Forms;
using TGC_ConjectureSuggesterApp;

/*
 *
 * This app renders some quarky advice based on a score inputed by the user's
 * stress level, personality, happiness, work environment, phisical activity etc.
 * It queries ChatGPT with a specific prompt and displays the results in a Dialogue.
 * It is not intended to be of any significance or to give any medical advice
 * hopefully it will give the useer a chuckle, a smile or a good old belly laugh!
 * ChatGPT was used to generate some of the baseline code and all of the whimsical phrases.
 * Idea man: Ted Dickey aka (Ra Grammaton)
 * Developer: David Strickland
 * Date: Feb 2024
 *
 *
 * */

namespace CosmicSocialDecoderApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormCosmicSuggester());
        }
    }
}