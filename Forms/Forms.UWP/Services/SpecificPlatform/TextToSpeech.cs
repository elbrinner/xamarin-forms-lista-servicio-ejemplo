using Forms.Services.SpecificPlatform;
using Forms.UWP.Services.SpecificPlatform;
using System;
using Windows.UI.Xaml.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech))]
namespace Forms.UWP.Services.SpecificPlatform
{
    public class TextToSpeech : ITextToSpeech
    {
        public TextToSpeech() { }

        public async void Speak(string text)
        {
            var mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}
