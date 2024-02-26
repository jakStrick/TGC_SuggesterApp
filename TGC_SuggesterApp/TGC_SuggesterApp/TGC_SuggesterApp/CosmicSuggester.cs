using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace TGC_ConjectureSuggesterApp
{
    internal class CosmicSuggester
    {
        public double SocialScore { get; set; }

        public string Intensity { get; set; }
        public string Happiness { get; set; }
        public string Awakening { get; set; }
        public string Laughter { get; set; }
        public string Influences { get; set; }
        public string Realizations { get; set; }
        public string Pfactors { get; set; }
        public string VoiceOf { get; set; }

        public async Task<string> RenderResults(CosmicSuggester csg)
        {
            return await GenerateFunSuggestionAsync(csg);
        }

        private async Task<string> GenerateFunSuggestionAsync(CosmicSuggester csg)
        {
            /* Intensity;
             Happiness;
             Awakening;
             Laughter;
             Influences;
             Realizations;
             Pfactors;
             VoiceOf;*/

            string prompt = $"From 3rd person perspective -- Initiate a Journey Synthesis with Cosmic Whimsy using these metrics:\r\n1. - Intensity-- What's your Intensity rated on a cosmic scale of 1-10:{csg.Intensity}\r\n2. - Happiness-- How happy are you rated on a scale of 1 - 5 quantified in moments of joy and happiness: {csg.Happiness}\r\n3. - Awakening-- the day the universe and you shared a secret: {csg.Awakening}\r\n4. - Laughter-- how the echoes of your laughter shaped your path, on a scale of 1 - 10: {csg.Laughter}\r\n5. - Influences-- the weight of the world on your spirit, rated 1 - 10:{csg.Influences}\r\n6. - Cosmic Realizations-- insights about God on your soul:{csg.Realizations}\r\n7. - Personalization Factor-- your traits and quirks that make you unique:{csg.Pfactors}\r\n\r\nCraft a narrative that mirrors this journey through a whimsical lens, weaving quantitative assessments with qualitative insights for a multifaceted reflection of their spiritual progression (don't write this part but respond in the voice of {csg.VoiceOf}.)";

            var queryResult = await QueryOpenAi.GetResult(prompt);

            AiQueryDeserialized aiQueryDeserialized = JsonConvert.DeserializeObject<AiQueryDeserialized>(queryResult);

            return " " + aiQueryDeserialized.choices[0].message.content;
        }
    }
}