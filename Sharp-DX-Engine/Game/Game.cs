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
using NekuSoul.SharpDX_Engine.Input;

namespace NekuSoul.SharpDX_Engine
{
    public class Game
    {
        public Scene Scene;
        public Timer Timer;
        //public Stopwatch _Stopwatch;
        public Renderer Renderer;
        private SwapChain swapChain;
        private Device1 device;
        private bool AllowUpdate;
        internal RenderForm form = new RenderForm();

        /// <summary>
        /// A Game powered by SharpDX
        /// </summary>
        /// <param name="Width">The width of the window</param>
        /// <param name="Height">The height of the window</param>
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
            form.GotFocus += form_GotFocus;
            form.LostFocus += form_LostFocus;
            TextureManager _TextureManager = new TextureManager(d2dRenderTarget);
            //swapChain.IsFullScreen = true;
            Renderer = new Renderer(d2dRenderTarget, _TextureManager);
            Timer = new Timer(1);
            Timer.Elapsed += _Timer_Elapsed;
            Timer.Start();
        }

        void form_LostFocus(object sender, EventArgs e)
        {
            Mouse.FormHasFocus = false;
        }

        void form_GotFocus(object sender, EventArgs e)
        {
            Mouse.FormHasFocus = true;
        }

        void form_SizeChanged(object sender, EventArgs e)
        {
            //ModeDescription MD = new ModeDescription(form.ClientSize.Width, form.ClientSize.Height,
            //                            new Rational(60, 1), Format.R8G8B8A8_UNorm);
            //swapChain.ResizeTarget(ref MD);
            //swapChain.ResizeBuffers(1, form.Width, form.Height, Format.A8_UNorm, SwapChainFlags.AllowModeSwitch);
        }

        void UpdateScene()
        {
            if (Scene != null)
            {
                Scene.Update();
            }
        }

        void DrawScene()
        {
            if (Scene != null)
            {
                Renderer.Draw(Scene.Draw());
            }
        }

        public void Run()
        {
            RenderLoop.Run(form, () =>
            {
                if (AllowUpdate)
                {
                    UpdateScene();
                    AllowUpdate = false;
                    return;
                }
                DrawScene();
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
            this.Scene = _Scene;
        }

        void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AllowUpdate = true;
        }
    }
}
