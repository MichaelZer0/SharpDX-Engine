using SharpDX;
using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System.IO;
using System.Threading;

namespace NekuSoul.SharpDX_Engine.Sound
{
    public class Sound
    {
        public Sound()
        {
            XAudio2 xaudio2 = new XAudio2();
            MasteringVoice masteringVoice = new MasteringVoice(xaudio2);
            SoundStream stream = new SoundStream(File.OpenRead(@"C:\ergon.wav"));
            WaveFormat waveFormat = stream.Format;
            AudioBuffer buffer = new AudioBuffer
            {
                Stream = stream.ToDataStream(),
                AudioBytes = (int)stream.Length,
                Flags = BufferFlags.EndOfStream
            };
            //stream.Close();

            SourceVoice sourceVoice = new SourceVoice(xaudio2, waveFormat, true);
            //sourceVoice.SubmitSourceBuffer(buffer, stream.DecodedPacketsInfo);
            sourceVoice.Start();
        }
    }
}
