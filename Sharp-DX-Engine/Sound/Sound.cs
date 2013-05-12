using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System.Collections.Generic;
using System.IO;

namespace NekuSoul.SharpDX_Engine.Sound
{
    public class Sound
    {
        private XAudio2 xaudio2;
        private MasteringVoice masteringVoice;
        private Dictionary<string, CachedSound> SoundManager;

        public Sound()
        {
            xaudio2 = new XAudio2();
            masteringVoice = new MasteringVoice(xaudio2);
            SoundManager = new Dictionary<string, CachedSound>();
        }

        public void PlaySound(string FileName)
        {
            if (!SoundManager.ContainsKey(FileName))
            {
                SoundManager.Add(FileName, new CachedSound(FileName));
            }
            SourceVoice sourceVoice = new SourceVoice(xaudio2, SoundManager[FileName].SoundStream.Format, true);
            sourceVoice.SubmitSourceBuffer(SoundManager[FileName].Buffer, SoundManager[FileName].SoundStream.DecodedPacketsInfo);
            sourceVoice.Start();
        }

        public void ClearSoundCache()
        {
            SoundManager.Clear();
        }
    }

    class CachedSound
    {
        public SoundStream SoundStream;
        public AudioBuffer Buffer;

        public CachedSound(string FileName)
        {
            SoundStream = new SoundStream(File.OpenRead("Ressources\\" + FileName + ".wav"));
            Buffer = new AudioBuffer
            {
                Stream = SoundStream.ToDataStream(),
                AudioBytes = (int)SoundStream.Length,
                Flags = BufferFlags.EndOfStream
            };
            SoundStream.Close();
        }
    }
}
