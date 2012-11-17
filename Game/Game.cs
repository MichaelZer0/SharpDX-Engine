using NekuSoul.SharpDX_Engine.Graphics;
using NekuSoul.SharpDX_Engine.Objects;
using SharpDX.Direct2D1;
using SharpDX.Direct3D10;
using SharpDX.DXGI;
using SharpDX.Windows;
using System;
using System.Diagnostics;
using System.Timers;
using AlphaMode = SharpDX.Direct2D1.AlphaMode;
using Device1 = SharpDX.Direct3D10.Device1;
using DriverType = SharpDX.Direct3D10.DriverType;
using Factory = SharpDX.DXGI.Factory;
using FeatureLevel = SharpDX.Direct3D10.FeatureLevel;
using Timer = System.Timers.Timer;

namespace NekuSoul.SharpDX_Engine
{
    public class Game
    {
        public Scene _Scene;
        public Timer _Timer;
        //public Stopwatch _Stopwatch;
        public Renderer _Renderer;
        SwapChain swapChain;
        Device1 device;
        bool AllowUpdate;
        public RenderForm form = new RenderForm();

        public Game(int Width, int Height)
        {
            GC.Collect();

            //RenderForm form = new RenderForm();
            form.Width = Width;
            form.Height = Height;

            // SwapChain description
            SwapChainDescription desc = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription =
                    new ModeDescription(form.ClientSize.Width, form.ClientSize.Height,
                                        new Rational(60, 1), Format.R8G8B8A8_UNorm),
                IsWindowed = true,
                OutputHandle = form.Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            // Create Device and SwapChain
            Device1.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.BgraSupport, desc, FeatureLevel.Level_10_0, out device, out swapChain);

            var d2dFactory = new SharpDX.Direct2D1.Factory();

            // Ignore all windows events
            Factory factory = swapChain.GetParent<Factory>();
            factory.MakeWindowAssociation(form.Handle, WindowAssociationFlags.IgnoreAll);

            // New RenderTargetView from the backbuffer
            Texture2D backBuffer = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
            RenderTargetView renderView = new RenderTargetView(device, backBuffer);

            Surface surface = backBuffer.QueryInterface<Surface>();

            RenderTarget d2dRenderTarget = new RenderTarget(d2dFactory, surface,
                                                            new RenderTargetProperties(new SharpDX.Direct2D1.PixelFormat(Format.Unknown, AlphaMode.Premultiplied)));

            form.SizeChanged += form_SizeChanged;
            TextureManager _TextureManager = new TextureManager(d2dRenderTarget);
            _Renderer = new Renderer(d2dRenderTarget, _TextureManager);
            _Timer = new Timer(1);
            _Timer.Elapsed += _Timer_Elapsed;
            _Timer.Start();
        }

        void form_SizeChanged(object sender, EventArgs e)
        {
            ModeDescription MD = new ModeDescription(form.ClientSize.Width, form.ClientSize.Height,
                                        new Rational(60, 1), Format.R8G8B8A8_UNorm);
            swapChain.ResizeTarget(ref MD);
            swapChain.ResizeBuffers(1, form.Width, form.Height, Format.A8_UNorm, SwapChainFlags.AllowModeSwitch);
        }

        void UpdateScene()
        {
            if (_Scene != null)
            {
                _Scene.Update();
                foreach (DrawableObject _DrawableObjet in _Scene.DrawableObjectList)
                {
                    _DrawableObjet.Update();
                }
            }
        }

        void DrawScene()
        {
            if (_Scene != null)
            {
                _Renderer.Draw(_Scene.DrawableObjectList);
            }
        }

        public void Run()
        {
            RenderLoop.Run(form, () =>
            {
                if (AllowUpdate)
                {
                    UpdateScene();
                    DrawScene();
                    AllowUpdate = false;
                    return;
                }
                swapChain.Present(0, PresentFlags.None);
                swapChain.ContainingOutput.WaitForVerticalBlank();
            });

            #region Close
            // Release all resources
            //renderView.Dispose();
            //backBuffer.Dispose();
            //device.ClearState();
            //device.Flush();
            //device.Dispose();
            //device.Dispose();
            //swapChain.Dispose();
            //factory.Dispose();
            #endregion
        }

        public void RunScene(Scene _Scene)
        {
            this._Scene = _Scene;
        }

        void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AllowUpdate = true;
        }
    }
}
