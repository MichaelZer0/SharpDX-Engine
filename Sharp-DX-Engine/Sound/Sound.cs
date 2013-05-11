using SharpDX;
using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System.IO;
using System.Threading;

namespace NekuSoul.SharpDX_Engine.Sound
{
    public class Sound
    {
        XAudio2 xaudio2;
        MasteringVoice masteringVoice;
        SourceVoice sourceVoice;
        AudioBuffer buffer;

        public Sound()
        {
            xaudio2 = new XAudio2();
            masteringVoice = new MasteringVoice(xaudio2);
            SoundStream stream = new SoundStream(File.OpenRead(@"C:\ergon.wav"));
            buffer = new AudioBuffer
            {
                Stream = stream.ToDataStream(),
                AudioBytes = (int)stream.Length,
                Flags = BufferFlags.EndOfStream
            };
            stream.Close();
            sourceVoice = new SourceVoice(xaudio2, stream.Format, true);
            sourceVoice.SubmitSourceBuffer(buffer, stream.DecodedPacketsInfo);
            sourceVoice.Start();
        }

        ~Sound()
        {
            masteringVoice.DestroyVoice();
            masteringVoice.Dispose();
            masteringVoice.Dispose();
            sourceVoice.Stop();
            sourceVoice.DestroyVoice();
            sourceVoice.Dispose();
            buffer.Stream.Dispose();
            xaudio2.Dispose();
        }
    }
}
