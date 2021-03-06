using System;
using System.Collections;
using SwinGameSDK;
using System.Collections.Generic;

namespace BattleShip
{
    public class GameResources
    {

        //Loading fonts
        private static void LoadFonts()
        {
            GameResources.NewFont("ArialLarge", "arial.ttf", 80);
            GameResources.NewFont("Courier", "cour.ttf", 14);
            GameResources.NewFont("CourierSmall", "cour.ttf", 8);
            GameResources.NewFont("Menu", "ffaccess.ttf", 8);
        }

        //loading imagines
        private static void LoadImages()
        {

            // Backgrounds
            GameResources.NewImage("Menu", "main_page.jpg");
            GameResources.NewImage("Discovery", "discover.jpg");
            GameResources.NewImage("Deploy", "deploy.jpg");

            // Deployment
            GameResources.NewImage("LeftRightButton", "deploy_dir_button_horiz.png");
            GameResources.NewImage("UpDownButton", "deploy_dir_button_vert.png");
            GameResources.NewImage("SelectedShip", "deploy_button_hl.png");
            GameResources.NewImage("PlayButton", "deploy_play_button.png");
            GameResources.NewImage("RandomButton", "deploy_randomize_button.png");

            // Ships
            for (int i = 1; (i <= 5); i++)
            {
                GameResources.NewImage(("ShipLR" + i), ("ship_deploy_horiz_" + (i + ".png")));
                GameResources.NewImage(("ShipUD" + i), ("ship_deploy_vert_" + (i + ".png")));
            }

            // Explosions
            GameResources.NewImage("Explosion", "explosion.png");
            GameResources.NewImage("Splash", "splash.png");
            //hit markers
            GameResources.NewImage("HitMarker", "explosionStill.png");
            GameResources.NewImage("MissMarker", "splashStill.png");
        }

        //Sounds
        private static void LoadSounds()
        {
            GameResources.NewSound("Error", "error.wav");
            GameResources.NewSound("Hit", "hit.wav");
            GameResources.NewSound("Sink", "sink.wav");
            GameResources.NewSound("Siren", "siren.wav");
            GameResources.NewSound("Miss", "watershot.wav");
            GameResources.NewSound("Winner", "winner.wav");
            GameResources.NewSound("Lose", "lose.wav");
        }

        //Music
        private static void LoadMusic()
        {
            GameResources.NewMusic("Background", "horrordrone.mp3");
        }


        //Gets a Font Loaded in the Resources
        public static Font GameFont(string font)
        {
            //what is in the square brackets is the key used to locate a section within the dictionary
            return _Fonts[font];
        }

        //Gets an Image loaded in the Resources
        public static Bitmap GameImage(string image)
        {
            return _Images[image];
        }

        //Gets an sound loaded in the Resources
        public static SoundEffect GameSound(string sound)
        {
            return _Sounds[sound];
        }

        //Gets the music loaded in the Resources
        public static Music GameMusic(string music)
        {
            return _Music[music];
        }

        //storage for all the game assets
        private static Dictionary<string, Bitmap> _Images = new Dictionary<string, Bitmap>();
        private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font>();
        private static Dictionary<string, SoundEffect> _Sounds = new Dictionary<string, SoundEffect>();
        private static Dictionary<string, Music> _Music = new Dictionary<string, Music>();

        //creating new image (bitmap) objects
        private static Bitmap _Background;
        private static Bitmap _Animation;
        private static Bitmap _LoaderFull;
        private static Bitmap _LoaderEmpty;
        //creating new font object
        private static Font _LoadingFont;
        //creating new soundEffect object
        private static SoundEffect _StartSound;

        /*<summary>
        *The Resources Class stores all of the Games Media Resources, such as Images, Fonts
        *Sounds, Music.
        *</summary>
        */
		public static void LoadResources()
        {
            int width;
            int height;
            width = SwinGame.ScreenWidth();
            height = SwinGame.ScreenHeight();
            SwinGame.ChangeScreenSize(800, 600);
            GameResources.ShowLoadingScreen();
            GameResources.ShowMessage("Loading fonts...", 0);
            GameResources.LoadFonts();
            SwinGame.Delay(100);
            GameResources.ShowMessage("Loading images...", 1);
            GameResources.LoadImages();
            SwinGame.Delay(100);
            GameResources.ShowMessage("Loading sounds...", 2);
            GameResources.LoadSounds();
            SwinGame.Delay(100);
            GameResources.ShowMessage("Loading music...", 3);
            GameResources.LoadMusic();
            SwinGame.Delay(100);
            SwinGame.Delay(100);
            GameResources.ShowMessage("Game loaded...", 5);
            SwinGame.Delay(100);
            GameResources.EndLoadingScreen(width, height);
        }

        /*<summary>
        * Shows the loading screen before the splash screen
        * </summary>
        */
        private static void ShowLoadingScreen()
        {
            _Background = SwinGame.LoadBitmap(SwinGame.PathToResource("SplashBack.png", ResourceKind.BitmapResource));
            SwinGame.DrawBitmap(_Background, 0, 0);
            SwinGame.RefreshScreen();
            SwinGame.ProcessEvents();
            _Animation = SwinGame.LoadBitmap(SwinGame.PathToResource("SwinGameAni.jpg", ResourceKind.BitmapResource));
            _LoadingFont = SwinGame.LoadFont(SwinGame.PathToResource("arial.ttf", ResourceKind.FontResource), 12);
            _StartSound = Audio.LoadSoundEffect(SwinGame.PathToResource("SwinGameStart.ogg", ResourceKind.SoundResource));
            _LoaderFull = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_full.png", ResourceKind.BitmapResource));
            _LoaderEmpty = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_empty.png", ResourceKind.BitmapResource));
            GameResources.PlaySwinGameIntro();
        }

        /* <summary>
         * Plays the swinGame splash screen
         * </summary> 
         */
        private static void PlaySwinGameIntro()
        {
            const int ANI_CELL_COUNT = 11;
            Audio.PlaySoundEffect(_StartSound);
            SwinGame.Delay(200);
            int i;
            for (i = 0; (i
                        <= (ANI_CELL_COUNT - 1)); i++)
            {
                SwinGame.DrawBitmap(_Background, 0, 0);
                SwinGame.Delay(20);
                SwinGame.RefreshScreen();
                SwinGame.ProcessEvents();
            }

            SwinGame.Delay(1500);
        }

        /* <summary>
         * Shows the battleship loading screen
         * </summary>
         */
        private static void ShowMessage(string message, int number)
        {
            const int BG_Y = 453;
            const int TX = 310;
            const int TY = 493;
            const int TW = 200;
            const int TH = 25;
            const int STEPS = 5;
            const int BG_X = 279;
            int fullW;
            Rectangle toDraw = new Rectangle();
            fullW = (260 * number) / STEPS;

            SwinGame.DrawBitmap(_LoaderEmpty, BG_X, BG_Y);
            SwinGame.DrawCell(_LoaderFull, 0, BG_X, BG_Y);
            SwinGame.DrawBitmapPart(_LoaderFull, 0, 0, fullW, 66, BG_X, BG_Y);
            toDraw.X = TX;
            toDraw.Y = TY;
            toDraw.Width = TW;
            toDraw.Height = TH;
            SwinGame.DrawTextLines(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, toDraw);
            SwinGame.DrawTextLines(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, TX, TY, TW, TH);
            SwinGame.RefreshScreen();
            SwinGame.ProcessEvents();
        }

        /* <summary>
         * Releasing all the resources that where used to display the loading screen
         * </summary>
         */ 
        private static void EndLoadingScreen(int width, int height)
        {
            SwinGame.ProcessEvents();
            SwinGame.Delay(500);
            SwinGame.ClearScreen();
            SwinGame.RefreshScreen();
            SwinGame.FreeFont(_LoadingFont);
            SwinGame.FreeBitmap(_Background);
            SwinGame.FreeBitmap(_Animation);
            SwinGame.FreeBitmap(_LoaderEmpty);
            SwinGame.FreeBitmap(_LoaderFull);
            Audio.FreeSoundEffect(_StartSound);
            SwinGame.ChangeScreenSize(width, height);
        }

        /* <summary>
         * Adding new fonts to the _Fonts object
         * </summary>
         */ 
        private static void NewFont(string fontName, string filename, int size)
        {
            _Fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size));
        }

        /* <summary>
         * Adding new imagies to the _Image object 
         * </summary
         */
        private static void NewImage(string imageName, string filename)
        {
            _Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource)));
        }

        /* <summary>
         * Adding new imagies (bitmaps) to be transparent to the _Image object 
         * </summary
         */
        private static void NewTransparentColorImage(string imageName, string fileName, Color transColor)
        {
            _Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(fileName, ResourceKind.BitmapResource), true, transColor));
        }

        /* <summary>
         * Adding new imagies to the _Image object 
         * </summary
         */
        private static void NewTransparentColourImage(string imageName, string fileName, Color transColor)
        {
            GameResources.NewTransparentColorImage(imageName, fileName, transColor);
        }

        /* <summary>
         * Adding new sounds to the _Sounds object 
         * </summary
         */
        private static void NewSound(string soundName, string filename)
        {
            _Sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }

        /* <summary>
         * Adding new music to the _music object 
         * </summary
         */
        private static void NewMusic(string musicName, string filename)
        {
            _Music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }

        /* <summary>
         * releasing the fonts from the heap
         * </summary
         */
        private static void FreeFonts()
        {
            foreach (Font obj in _Fonts.Values)
            {
                SwinGame.FreeFont(obj);
            }

        }

        /* <summary>
         * releasing the images from the heap
         * </summary
         */
        private static void FreeImages()
        {
            foreach (Bitmap obj in _Images.Values)
            {
                SwinGame.FreeBitmap(obj);
            }

        }

        /* <summary>
         * releasing the sounds from the heap
         * </summary
         */
        private static void FreeSounds()
        {
            foreach (SoundEffect obj in _Sounds.Values)
            {
                Audio.FreeSoundEffect(obj);
            }

        }

        /* <summary>
         * releasing the music from the heap
         * </summary
         */
        private static void FreeMusic()
        {
            foreach (Music obj in _Music.Values)
            {
                Audio.FreeMusic(obj);
            }

        }

        /* <summary>
         * running all of the release methods to free all the resources from the memory
         * </summary
         */
        public static void FreeResources()
        {
            GameResources.FreeFonts();
            GameResources.FreeImages();
            GameResources.FreeMusic();
            GameResources.FreeSounds();
            SwinGame.ProcessEvents();
        }
    }
}
 