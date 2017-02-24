using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Forms.iOS.Services.SpecificPlatform;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace Forms.iOS.Services.SpecificPlatform
{
    using AVFoundation;
    using Forms.Services.SpecificPlatform;

    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation() { }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}