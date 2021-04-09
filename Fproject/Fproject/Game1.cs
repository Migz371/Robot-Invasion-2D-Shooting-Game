using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Fproject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont buttonfont;
        SpriteFont fontinterface;

        enum GameState
        {
            MainMenu,
            Instructions,
            Playing,
            Level2,
            Victory
        }

        GameState CurrentGameState = GameState.MainMenu;

        int screenwidth = 1500 , screenHeight = 750;

        Button btnPlay;
        Button btnManual;
        Button btnContinue;
        Button btnMainMenu;




        //Player
        Texture2D playerTexture;
        Rectangle playerDisplay;
        Rectangle playerSource;
        Color playerColor;
        int playerhealth;

        //Player HealthBar
        Texture2D healthTexture;
        Rectangle healthRectangle;

        //enemy
        Texture2D enemyTexture;
        Rectangle enemySource;
        Rectangle enemyDisplay;
        Color enemyColor;

        //BG
        Texture2D gamebgTexture;
        Rectangle gamebgRectangle;
        Color gamebgColor;

        //trigger
        Texture2D triggerTexture;
        Rectangle triggerRectangle;
        Color triggerColor;

        //
        Texture2D doorTexture;
        Rectangle doorRectangle;
        Color doorColor;

        List<Bullet> bullet;
        List<Tiles> tiles;
        List<Enemy> enemy = new List<Enemy>();
        List<Explosion> explosion;
        List<Door> door = new List<Door>();

        Enemy e,boss1;
        Door d,d2;
        Bullet b;


        bool checkfire;
        bool checkface = true;
        bool jump = false;
        bool checkammo = true;
        bool checkmove;
        bool summonboss1 = false;
        bool checkLevel1;
        bool checkclick;
        int ammo = 20;
        int score,keptscore;
        int delay;
        int delayplayer;
        int changeAnim;
        int tileset;
        int enemyset;
        int jumplimit;

        SoundEffect bgMusic;
        SoundEffectInstance bgMusicI;

        //Gun shot sound
        SoundEffect gunshotSE;
        SoundEffectInstance gunshotSEI;

        //Reload sound
        SoundEffect reloadSE;
        SoundEffectInstance reloadSEI;

        //enemyhit sound
        SoundEffect enemyhitSE;
        SoundEffectInstance enemyhitSEI;

        //explosion sound
        SoundEffect explosionSE;
        SoundEffectInstance explosionSEI;

        //no ammo sound
        SoundEffect noammoSE;
        SoundEffectInstance noammoSEI;

        //menu sound
        SoundEffect menuSE;
        SoundEffectInstance menuSEI;

        //disc get sound
        SoundEffect discgetSE;
        SoundEffectInstance discgetSEI;

        //door enter sound
        SoundEffect doorSE;
        SoundEffectInstance doorSEI;

        SoundEffect victorySE;
        SoundEffectInstance victorySEI;

        //camera
        Matrix camPos;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

           
        }
        

        protected override void Initialize()
        {
            
            score = 0;
            playerhealth = 200;
            camPos = Matrix.Identity;
            enemy.Clear();
            ammo = 20;
            checkammo = true;



            healthTexture = Content.Load<Texture2D>("healthbar");


            playerTexture = Content.Load<Texture2D>("player");
            playerSource = new Rectangle(0, 0, playerTexture.Width / 5,
                playerTexture.Height / 2);
            playerDisplay = new Rectangle(60, 520, 150, 150);
            playerColor = Color.White;
            delay = 0;

            enemyTexture = Content.Load<Texture2D>("Enemy1");
            enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                 playerTexture.Height / 2);
            enemyDisplay = new Rectangle(760, 520, 150, 150);
            enemyColor = Color.White;
            e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 15);
            enemy.Add(e);

            enemyTexture = Content.Load<Texture2D>("Enemy1");
            enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                 playerTexture.Height / 2);
            enemyDisplay = new Rectangle(2060, 180, 150, 150);
            enemyColor = Color.White;
            e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 15);
            enemy.Add(e);


            enemyset = 4000;
            for (int i = 0; i < 2; i++)
            {
                enemyTexture = Content.Load<Texture2D>("Enemy1");
                enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                     playerTexture.Height / 2);
                enemyDisplay = new Rectangle(enemyset += 200, 520, 150, 150);
                enemyColor = Color.White;
                e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 15);
                enemy.Add(e);
            }



            bullet = new List<Bullet>();
            tiles = new List<Tiles>();

            gamebgTexture = Content.Load<Texture2D>("bggame");
            gamebgRectangle = new Rectangle(0, 0, 4100, 2100);
            gamebgColor = Color.White;


            //trigger

            triggerTexture = Content.Load<Texture2D>("trigger");
            triggerRectangle = new Rectangle(2800, 550, 80, 80);
            triggerColor = Color.White;



            tileset = 0;
            for (int i = 0; i < 11; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 670, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            tileset = 1100;
            for (int i = 0; i < 3; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 500, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }


            tileset = 1440;
            for (int i = 0; i < 3; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 330, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            tileset = 1820;
            for (int i = 0; i < 3; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 500, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            tileset = 2260;

            for (int i = 0; i < 17; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 670, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }






            base.Initialize();
        }

        private void Level2()
        {
            
            menuSEI.Stop();
            playerhealth = 200;
            camPos = Matrix.Identity;
            enemy.Clear();
            ammo = 20;
            checkammo = true;
            


            healthTexture = Content.Load<Texture2D>("healthbar");


            playerTexture = Content.Load<Texture2D>("player");
            playerSource = new Rectangle(0, 0, playerTexture.Width / 5,
                playerTexture.Height / 2);
            playerDisplay = new Rectangle(60, 220, 150, 150);
            playerColor = Color.White;
            delay = 0;

            //enemy level 2

            enemyTexture = Content.Load<Texture2D>("Enemy1");
            enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                 playerTexture.Height / 2);
            enemyDisplay = new Rectangle(760, 200, 150, 150);
            enemyColor = Color.White;
            e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 15);
            enemy.Add(e);

            enemyTexture = Content.Load<Texture2D>("Enemy1");
            enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                 playerTexture.Height / 2);
            enemyDisplay = new Rectangle(1960, 410, 150, 150);
            enemyColor = Color.White;
            e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 15);
            enemy.Add(e);


            enemyset = 2860;
            for (int i = 0; i < 3; i++)
            {
                enemyTexture = Content.Load<Texture2D>("Enemy1");
                enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                     playerTexture.Height / 2);
                enemyDisplay = new Rectangle(enemyset += 200, 520, 150, 150);
                enemyColor = Color.White;
                e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 15);
                enemy.Add(e);
            }

            enemyTexture = Content.Load<Texture2D>("Enemy1");
            enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                 playerTexture.Height / 2);
            enemyDisplay = new Rectangle(3960, 520, 150, 150);
            enemyColor = Color.White;
            e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 15);
            enemy.Add(e);

            bullet = new List<Bullet>();
            tiles = new List<Tiles>();

            gamebgTexture = Content.Load<Texture2D>("bggame");
            gamebgRectangle = new Rectangle(0, 0, 4100, 2100);
            gamebgColor = Color.White;


            //trigger

            triggerTexture = Content.Load<Texture2D>("trigger");
            triggerRectangle = new Rectangle(2800, 550, 80, 80);
            triggerColor = Color.White;


            //tileset level 2
            tileset = 0;
            for (int i = 0; i < 5; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 370, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            tileset = 560;

            for (int i = 0; i < 3; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 470, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            tileset += 160;
            for (int i = 0; i < 3; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 570, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            tileset += 160;
            for (int i = 0; i < 19; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 670, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            tileset += 230;
            for (int i = 0; i < 3; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 570, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            for (int i = 0; i < 3; i++)
            {
                Texture2D tilesTexture = Content.Load<Texture2D>("tiles");
                Rectangle tilesRectangle = new Rectangle(tileset, 370, 80, 80);
                Color tilesColor = Color.White;
                tileset += 80;
                Tiles t = new Tiles(tilesTexture, tilesRectangle, tilesColor);
                tiles.Add(t);
            }

            
        }


        protected override void LoadContent()
        {

            buttonfont = Content.Load<SpriteFont>("buttonfont");
            fontinterface = Content.Load<SpriteFont>("fontinterface");


            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenwidth;
            graphics.ApplyChanges();


            btnPlay = new Button(Content.Load<Texture2D>("button"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 450));

            btnContinue = new Button(Content.Load<Texture2D>("button"), graphics.GraphicsDevice);
            btnContinue.setPosition(new Vector2(750, 450));

            btnManual = new Button(Content.Load<Texture2D>("button"), graphics.GraphicsDevice);
            btnManual.setPosition(new Vector2(550, 600));

            btnMainMenu = new Button(Content.Load<Texture2D>("button"), graphics.GraphicsDevice);
            btnMainMenu.setPosition(new Vector2(1100, 600));




            explosion = new List<Explosion>();

            bgMusic = Content.Load<SoundEffect>("bgmusic");
            bgMusicI = bgMusic.CreateInstance();
            bgMusicI.IsLooped = true;
            bgMusicI.Volume = .1f;

            menuSE = Content.Load<SoundEffect>("menumusic");
            menuSEI = menuSE.CreateInstance();
            menuSEI.IsLooped = true;
            menuSEI.Volume = .2f;



            //Gun shot
            gunshotSE = Content.Load<SoundEffect>("gunsound1");
            gunshotSEI = gunshotSE.CreateInstance();
            gunshotSEI.Volume = .1f;

            //Reload sound
            reloadSE = Content.Load<SoundEffect>("reload"); ;
            reloadSEI = reloadSE.CreateInstance();
            gunshotSEI.Volume = .1f;

            //enemyhit sound
            enemyhitSE = Content.Load<SoundEffect>("enemyhit");
            enemyhitSEI = enemyhitSE.CreateInstance();
            gunshotSEI.Volume = .1f;

            //Explosion sound
            explosionSE = Content.Load<SoundEffect>("explosionsfx"); 
            explosionSEI = explosionSE.CreateInstance();

            //No ammo sound
            noammoSE = Content.Load<SoundEffect>("noammo"); 
            noammoSEI = noammoSE.CreateInstance();

            //disc get sound
            discgetSE = Content.Load<SoundEffect>("discget");
            discgetSEI = discgetSE.CreateInstance();

            //door sound
            doorSE = Content.Load<SoundEffect>("doorsound");
            doorSEI = doorSE.CreateInstance();

            victorySE = Content.Load<SoundEffect>("victorysound");
            victorySEI = victorySE.CreateInstance();
            victorySEI.Volume = .1f;



        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();



            switch (CurrentGameState)
            {
                case GameState.MainMenu:

                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        checkclick = true;
                    }
                    else
                    {
                        checkclick = false;
                    }


                    IsMouseVisible = true;
                    menuSEI.Play();
                    if (btnPlay.isClicked == true && checkclick)
                    {
                     
                        CurrentGameState = GameState.Playing;
                        checkLevel1 = false;
                    }
                    
                    if (btnManual.isClicked == true && checkclick) CurrentGameState = GameState.Instructions;
                    if (btnContinue.isClicked == true && checkclick)
                    {

                        //continue setup
                        if (checkLevel1)
                        {
                            score = keptscore;
                            menuSEI.Stop();
                            CurrentGameState = GameState.Level2;
                            Level2();
                        }
                       



                    }

                    btnPlay.Update(mouse);
                    btnManual.Update(mouse);
                    btnContinue.Update(mouse);

                    break;

                case GameState.Instructions:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        CurrentGameState = GameState.MainMenu;
                    }


                    break;


                    //victory feat

                case GameState.Victory:

                    IsMouseVisible = true;
                    if (btnMainMenu.isClicked == true && checkclick)
                    {
                        CurrentGameState = GameState.MainMenu;
                        Initialize();
                    }

                    btnMainMenu.Update(mouse);
                    victorySEI.Play();


                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        checkclick = true;
                    }
                    else
                    {
                        checkclick = false;
                    }


                    if (Keyboard.GetState().IsKeyDown(Keys.Escape) && checkclick)
                    {
                        CurrentGameState = GameState.MainMenu;
                    }
                    break;



                case GameState.Playing:
                    IsMouseVisible = false;
                    menuSEI.Stop();
                    bgMusicI.Play();
                    healthRectangle = new Rectangle(200, 25, playerhealth, 30);


                        //back to menu
                        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        bgMusicI.Stop();
                        Initialize();               
                        camPos = Matrix.Identity;
                        CurrentGameState = GameState.MainMenu;


                    }


                        // Player HP decrease
                        for (int i = 0; i < enemy.Count; i++)
                    {
                        if (playerDisplay.Intersects(enemy[i].EnemyDisplay))
                        {
                            playerhealth -= 2;
             
                        }
                    }


                    if (playerhealth == 0)
                    {
                        
                        bgMusicI.Stop();
                        tiles.Clear();
                        Initialize();
                    }


                    if (playerDisplay.X >= 300 && checkmove && checkface && playerDisplay.X <= 2900)
                    {
                        camPos = Matrix.CreateTranslation(camPos.Translation.X - 4,

                                                          camPos.Translation.Y,
                                                          camPos.Translation.Z);



                    }
                    if (playerDisplay.X >= 300 && checkmove && !checkface && playerDisplay.X <= 2900)
                    {
                        camPos = Matrix.CreateTranslation(camPos.Translation.X + 4,

                                                          camPos.Translation.Y,
                                                          camPos.Translation.Z);
                    }



                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        playerDisplay.X -= 4;
                        playerSource.Y = playerTexture.Height / 2;
                        PlayAnimation(2);
                        checkface = false;
                        checkmove = true;

                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        playerDisplay.X += 4;
                        playerSource.Y = 0;
                        PlayAnimation(0);
                        checkface = true;
                        checkmove = true;
                    }
                    else
                    {
                        checkmove = false;
                    }


                    //Fall restart
                    
                    if(playerDisplay.Y > screenHeight + 70)

                    {
                        bgMusicI.Stop();
                        tiles.Clear();
                        Initialize();
                    }



                    // Reload
                    if (Keyboard.GetState().IsKeyDown(Keys.R) && ammo == 0)
                    {
                        ammo = 20;
                        checkammo = true;
                        reloadSEI.Play();
                    }

                    // Gun fire

                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && !checkammo && !checkfire)
                    {
                        noammoSEI.Play();
                        checkfire = true;
                    }


                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && !checkfire)
                    {
                        Texture2D bulletTexture = Content.Load<Texture2D>("bullet");
                        Color bulletColor = Color.White;


                        if (ammo == 0)
                        {
                            checkammo = false;
                        }

                        else if (checkface && ammo != 0)
                        {
                            Rectangle bulletRectangle = new Rectangle(playerDisplay.X + 130,
                            playerDisplay.Y + 70, 25, 8);
                            b = new Bullet(bulletTexture,
                                bulletRectangle, bulletColor);
                            bullet.Add(b);
                            checkfire = true;
                            ammo--;
                        }
                        else if (!checkface && ammo != 0)
                        {
                            Rectangle bulletRectangle = new Rectangle(playerDisplay.X,
                                playerDisplay.Y + 70, 25, 8);
                            b = new Bullet(bulletTexture,
                                bulletRectangle, bulletColor);
                            bullet.Add(b);
                            checkfire = true;
                            ammo--;
                        }

                    }
                    else if (Mouse.GetState().LeftButton == ButtonState.Released)
                    {
                        checkfire = false;
                    }

                    // GUN SHOT SOUND FX
                    if (checkfire && ammo != 0)
                    {
                        gunshotSEI.Play();
                    }
                    else
                    {
                        gunshotSEI.Stop();
                    }

                    //COMMENT BULLET

                    //      for(int i = 0; i < bullet.Count; i++)
                    //    {


                    foreach (Bullet b in bullet)
                    {

                        if (b.BulletRectangle.X > playerDisplay.X)
                        {
                            b.moveBulletR();
                        }
                        else
                        {
                            b.moveBulletL();
                        }
                    }

                    //player intersect trigger

                    if (playerDisplay.Intersects(triggerRectangle))
                    {
                        summonboss1 = true;
                        discgetSEI.Play();
                        triggerRectangle.Y = 1000;
                        enemyTexture = Content.Load<Texture2D>("Enemy1");
                        enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                             playerTexture.Height / 2);
                        enemyDisplay = new Rectangle(enemyset, 200, 480, 500);
                        enemyColor = Color.White;
                        boss1 = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 60);
                        enemy.Add(boss1);
                    }

                    if (summonboss1 && boss1.enemyHealth == 0)
                    {
                        


                        doorTexture = Content.Load<Texture2D>("door");
                        doorRectangle = new Rectangle(3500, boss1.EnemyDisplay.Y + 320, 100, 150);
                        doorColor = Color.White;
                        d = new Door(doorTexture, doorRectangle, doorColor);
                        door.Add(d);

                    }


                    for (int i = 0; i < door.Count; i++)
                    {
                        if (playerDisplay.Intersects(door[i].DoorRectangle))
                        {
                            doorSEI.Play();
                            bgMusicI.Stop();
                            Level2();
                            camPos = Matrix.Identity;
                            CurrentGameState = GameState.Level2;
                            summonboss1 = false;
                            checkLevel1 = true;
                            keptscore = score;
                            door.Clear();

                        }


                    }



                    // PLAYER INTERSECTS WITH TILE
                    for (int i = 0; i < tiles.Count; i++)
                    {
                        
                        if (Keyboard.GetState().IsKeyDown(Keys.Space) && jump == false)
                        {
                                playerDisplay.Y -= 1;
                            

                            if (jump == false && jumplimit >= playerDisplay.Y + 400)
                            {
                                jump = true;
                            }

                        }

                        else if (playerDisplay.Intersects(tiles[i].TilesRectangle))
                        {
                            playerDisplay.Y = tiles[i].TilesRectangle.Y - 150;
                            jump = false;
                            jumplimit = playerDisplay.Y;
                        }

                        else if (!(playerDisplay.Intersects(tiles[i].TilesRectangle)))
                        {
                            jump = true;
               
                        }

                    }






                    playerDisplay.Y += 8;

                    for (int j = 0; j < tiles.Count; j++)
                    {
                        for (int i = 0; i < bullet.Count; i++)
                        {
                            if (bullet[i].BulletRectangle.Intersects(tiles[j].TilesRectangle))
                            {
                                bullet.Remove(bullet[i]);
                            }


                        }
                    }


                    //ENEMY MOVEMENT


                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].enemyMoveX(2);
                       
                        if (delay >= 5)
                        {
                            enemy[i].animateEnemyXR(enemy[i].EnemySource.Width);
                            delay = 0;
                        }

     
                        delay++;




                        continue;
                    }


                    // bullet hit effect on enemies

                    for (int j = 0; j < enemy.Count; j++)
                    {
                        for (int i = 0; i < bullet.Count; i++)
                        {
                            if (bullet[i].BulletRectangle.Intersects(enemy[j].EnemyDisplay))
                            {
                                enemy[j].enemyHealth--;
                                bullet.Remove(bullet[i]);
                                enemyhitSEI.Play();


                                if (enemy[j].enemyHealth == 0)
                                {
                                    explosionSEI.Play();
                                    Texture2D explosionTexture = Content.Load<Texture2D>("explosion");
                                    Rectangle explosionDisplay = new Rectangle(enemy[j].EnemyDisplay.X, enemy[j].EnemyDisplay.Y, 150, 150);
                                    Rectangle explosionSource = new Rectangle(0, 0, explosionTexture.Width / 5, explosionTexture.Height / 2);
                                    Color explosionColor = Color.White;
                                    Explosion explode = new Explosion(explosionTexture, explosionDisplay, explosionSource, explosionColor);
                                    enemy.Remove(enemy[j]);
                                    explosion.Add(explode);
                                    score += 200;
                                    break;
                                }
                            }
                        }
                    }

                    //bullet despawn
                    foreach (Bullet b in bullet)
                    {
                        if (b.BulletRectangle.X >= playerDisplay.X + 1520 || b.BulletRectangle.X <= playerDisplay.X - 1220)
                        {
                            bullet.Remove(b);
                            break;
                        }

                    }




                    // explosion animation
                    if (delay >= 5)
                    {
                        for (int i = 0; i < explosion.Count; i++)
                        {
                            if (explosion[i].ExplosionSource.X < explosion[i].ExplosionSource.Width * 5)
                            {
                                explosion[i].animateExplosionX(explosion[i].ExplosionSource.Width);
                            }
                            if (!(explosion[i].ExplosionSource.X < explosion[i].ExplosionSource.Width * 5))
                            {
                                explosion.Remove(explosion[i]);
                            }
                        }
                        delay = 0;
                    }
                    delay++;

                    break;

                case GameState.Level2:

                    

                    IsMouseVisible = false;
                    
                    bgMusicI.Play();
                    healthRectangle = new Rectangle(200, 25, playerhealth, 30);



                    //back to menu
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        bgMusicI.Stop();
                        Initialize();
                        camPos = Matrix.Identity;
                        CurrentGameState = GameState.MainMenu;


                    }


                    // Player HP decrease
                    for (int i = 0; i < enemy.Count; i++)
                    {
                        if (playerDisplay.Intersects(enemy[i].EnemyDisplay))
                        {
                            playerhealth -= 2;

                        }
                    }


                    if (playerhealth == 0)
                    {
                        score = keptscore;
                        bgMusicI.Stop();
                        tiles.Clear();
                        Level2();
                    }


                    if (playerDisplay.X >= 300 && checkmove && checkface && playerDisplay.X <= 2900)
                    {
                        camPos = Matrix.CreateTranslation(camPos.Translation.X - 4,

                                                          camPos.Translation.Y,
                                                          camPos.Translation.Z);



                    }
                    if (playerDisplay.X >= 300 && checkmove && !checkface && playerDisplay.X <= 2900)
                    {
                        camPos = Matrix.CreateTranslation(camPos.Translation.X + 4,

                                                          camPos.Translation.Y,
                                                          camPos.Translation.Z);
                    }



                    if (Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        playerDisplay.X -= 4;
                        playerSource.Y = playerTexture.Height / 2;
                        PlayAnimation(2);
                        checkface = false;
                        checkmove = true;

                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        playerDisplay.X += 4;
                        playerSource.Y = 0;
                        PlayAnimation(0);
                        checkface = true;
                        checkmove = true;
                    }
                    else
                    {
                        checkmove = false;
                    }


                    //Fall restart

                    if (playerDisplay.Y > screenHeight + 70)

                    {
                        bgMusicI.Stop();
                        tiles.Clear();
                        playerhealth = 0;
                    }



                    // Reload
                    if (Keyboard.GetState().IsKeyDown(Keys.R) && ammo == 0)
                    {
                        ammo = 20;
                        checkammo = true;
                        reloadSEI.Play();
                    }

                    // Gun fire

                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && !checkammo && !checkfire)
                    {
                        noammoSEI.Play();
                        checkfire = true;
                    }


                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && !checkfire)
                    {
                        Texture2D bulletTexture = Content.Load<Texture2D>("bullet");
                        Color bulletColor = Color.White;


                        if (ammo == 0)
                        {
                            checkammo = false;
                        }

                        else if (checkface && ammo != 0)
                        {
                            Rectangle bulletRectangle = new Rectangle(playerDisplay.X + 130,
                            playerDisplay.Y + 70, 25, 8);
                            Bullet b = new Bullet(bulletTexture,
                                bulletRectangle, bulletColor);
                            bullet.Add(b);
                            checkfire = true;
                            ammo--;
                        }
                        else if (!checkface && ammo != 0)
                        {
                            Rectangle bulletRectangle = new Rectangle(playerDisplay.X,
                                playerDisplay.Y + 70, 25, 8);
                            Bullet b = new Bullet(bulletTexture,
                                bulletRectangle, bulletColor);
                            bullet.Add(b);
                            checkfire = true;
                            ammo--;
                        }

                    }
                    else if (Mouse.GetState().LeftButton == ButtonState.Released)
                    {
                        checkfire = false;
                    }

                    // GUN SHOT SOUND FX
                    if (checkfire && ammo != 0)
                    {
                        gunshotSEI.Play();
                    }
                    else
                    {
                        gunshotSEI.Stop();
                    }



                    foreach (Bullet b in bullet)
                    {

                        if (b.BulletRectangle.X > playerDisplay.X)
                        {
                            b.moveBulletR();
                        }
                        else
                        {
                            b.moveBulletL();
                        }
                    }



                    //player intersect trigger

                    if (playerDisplay.Intersects(triggerRectangle))
                    {
                        summonboss1 = true;
                        discgetSEI.Play();
                        triggerRectangle.Y = 1000;


                        // boss level 2
                        enemyTexture = Content.Load<Texture2D>("Enemy1");
                        enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                             playerTexture.Height / 2);
                        enemyDisplay = new Rectangle(4100, 200, 480, 500);
                        enemyColor = Color.White;
                        e = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 60);
                        enemy.Add(e);

                        enemyTexture = Content.Load<Texture2D>("Enemy1");
                        enemySource = new Rectangle(0, 0, playerTexture.Width / 5,
                             playerTexture.Height / 2);
                        enemyDisplay = new Rectangle(4880, 200, 480, 500);
                        enemyColor = Color.White;
                        boss1 = new Enemy(enemyTexture, enemyDisplay, enemySource, enemyColor, 60);
                        enemy.Add(boss1);
                    }

                    if (summonboss1 && boss1.enemyHealth == 0)
                    {

                        // door level 2
                       


                        doorTexture = Content.Load<Texture2D>("door");
                        doorRectangle = new Rectangle(3500, 220, 100, 150);
                        doorColor = Color.White;
                        d2 = new Door(doorTexture, doorRectangle, doorColor);
                        door.Add(d2);
                        

                    }

                    for (int i = 0; i < door.Count; i++)
                    {
                        if (playerDisplay.Intersects(d2.DoorRectangle))
                        {
                            camPos = Matrix.Identity;
                            doorSEI.Play();
                            bgMusicI.Stop();                            
                            summonboss1 = false;
                            door.Clear();
                            checkLevel1 = false;
                            CurrentGameState = GameState.Victory;

                        }


                    }



                    // PLAYER INTERSECTS WITH TILE
                    for (int i = 0; i < tiles.Count; i++)
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space) && jump == false)
                        {
                            playerDisplay.Y -= 1;


                            if (jump == false && jumplimit >= playerDisplay.Y + 400)
                            {
                                jump = true;
                            }

                        }

                        else if (playerDisplay.Intersects(tiles[i].TilesRectangle))
                        {
                            playerDisplay.Y = tiles[i].TilesRectangle.Y - 150;
                            jump = false;
                            jumplimit = playerDisplay.Y;
                        }

                        else if (!(playerDisplay.Intersects(tiles[i].TilesRectangle)))
                        {
                            jump = true;

                        }

                    }






                    playerDisplay.Y += 8;

                    for (int j = 0; j < tiles.Count; j++)
                    {
                        for (int i = 0; i < bullet.Count; i++)
                        {
                            if (bullet[i].BulletRectangle.Intersects(tiles[j].TilesRectangle))
                            {
                                bullet.Remove(bullet[i]);
                            }


                        }
                    }


                    //ENEMY MOVEMENT


                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].enemyMoveX(2);
                        if (delay >= 5)
                        {
                            enemy[i].animateEnemyXR(enemy[i].EnemySource.Width);
                            delay = 0;
                        }

                     



                        delay++;
                        continue;
                    }


                    // bullet hit effect on enemies

                    for (int j = 0; j < enemy.Count; j++)
                    {
                        for (int i = 0; i < bullet.Count; i++)
                        {
                            if (bullet[i].BulletRectangle.Intersects(enemy[j].EnemyDisplay))
                            {
                                enemy[j].enemyHealth--;
                                bullet.Remove(bullet[i]);
                                enemyhitSEI.Play();


                                if (enemy[j].enemyHealth == 0)
                                {
                                    explosionSEI.Play();
                                    Texture2D explosionTexture = Content.Load<Texture2D>("explosion");
                                    Rectangle explosionDisplay = new Rectangle(enemy[j].EnemyDisplay.X, enemy[j].EnemyDisplay.Y, 150, 150);
                                    Rectangle explosionSource = new Rectangle(0, 0, explosionTexture.Width / 5, explosionTexture.Height / 2);
                                    Color explosionColor = Color.White;
                                    Explosion explode = new Explosion(explosionTexture, explosionDisplay, explosionSource, explosionColor);
                                    enemy.Remove(enemy[j]);
                                    explosion.Add(explode);
                                    score += 200;
                                    break;
                                }
                            }
                        }
                    }

                    //bullet despawn
                    foreach (Bullet b in bullet)
                    {
                        if (b.BulletRectangle.X >= playerDisplay.X + 1520 || b.BulletRectangle.X <= playerDisplay.X - 1220)
                        {
                            bullet.Remove(b);
                            break;
                        }

                    }




                    // explosion animation
                    if (delay >= 5)
                    {
                        for (int i = 0; i < explosion.Count; i++)
                        {
                            if (explosion[i].ExplosionSource.X < explosion[i].ExplosionSource.Width * 5)
                            {
                                explosion[i].animateExplosionX(explosion[i].ExplosionSource.Width);
                            }
                            if (!(explosion[i].ExplosionSource.X < explosion[i].ExplosionSource.Width * 5))
                            {
                                explosion.Remove(explosion[i]);
                            }
                        }
                        delay = 0;
                    }
                    delay++;

                    break;
                    

            }
            
            
            
            
            
            
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camPos);


            switch (CurrentGameState)
            {
                case GameState.MainMenu:

                    spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenwidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    btnManual.Draw(spriteBatch);
                    btnContinue.Draw(spriteBatch);


                    spriteBatch.DrawString(buttonfont, "Start", new Vector2(470, 480), Color.White);
                    spriteBatch.DrawString(buttonfont, "Continue", new Vector2(825, 480), Color.White);
                    spriteBatch.DrawString(buttonfont, "Instructions", new Vector2(585, 625), Color.White);

                    
                    break;

                case GameState.Instructions:
                    spriteBatch.Draw(Content.Load<Texture2D>("instruc"), new Rectangle(0, 0, screenwidth, screenHeight), Color.White);
                    break;

                case GameState.Victory:
                    spriteBatch.Draw(Content.Load<Texture2D>("victory"), new Rectangle(0, 0, screenwidth, screenHeight), Color.White);
                    
                    btnMainMenu.Draw(spriteBatch);
                    spriteBatch.DrawString(buttonfont, "Main Menu", new Vector2(1150, 625), Color.White);
                    spriteBatch.DrawString(buttonfont, "Score: " + score.ToString(), new Vector2(20, 640), Color.White);
                    break;


                case GameState.Playing:

                    spriteBatch.Draw(gamebgTexture, gamebgRectangle,
              gamebgColor);

                    spriteBatch.Draw(playerTexture, playerDisplay,
                      playerSource, playerColor);

                    spriteBatch.Draw(triggerTexture,
                        triggerRectangle, triggerColor);

                    

                    foreach (Explosion e in explosion)
                    {
                        spriteBatch.Draw(e.ExplosionTexture, e.ExplosionDisplay, e.ExplosionSource, e.ExplosionColor);
                    }


                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].Draw(spriteBatch);
                        spriteBatch.DrawString(fontinterface, "HP: " + 
                            enemy[i].enemyHealth.ToString(), new Vector2(enemy[i].EnemyDisplay.X, 
                            enemy[i].EnemyDisplay.Y), Color.White);
                    }

                    for (int i = 0; i < door.Count; i++)
                    {
                        spriteBatch.Draw(door[i].DoorTexture,
                        door[i].DoorRectangle, door[i].DoorColor);
                    }



                    for (int i = 0; i < bullet.Count; i++)
                    {
                        spriteBatch.Draw(bullet[i].BulletTexture,
                        bullet[i].BulletRectangle, bullet[i].BulletColor);

                    }

                    for (int i = 0; i < tiles.Count; i++)
                    {
                        spriteBatch.Draw(tiles[i].TilesTexture,
                        tiles[i].TilesRectangle, tiles[i].TilesColor);

                    }
                    break;

                case GameState.Level2:

                    spriteBatch.Draw(gamebgTexture, gamebgRectangle,
              gamebgColor);

                    spriteBatch.Draw(playerTexture, playerDisplay,
                      playerSource, playerColor);

                    spriteBatch.Draw(triggerTexture,
                        triggerRectangle, triggerColor);



                    foreach (Explosion e in explosion)
                    {
                        spriteBatch.Draw(e.ExplosionTexture, e.ExplosionDisplay, e.ExplosionSource, e.ExplosionColor);
                    }


                    for (int i = 0; i < enemy.Count; i++)
                    {
                        enemy[i].Draw(spriteBatch);
                        spriteBatch.DrawString(fontinterface, "HP: " +
                            enemy[i].enemyHealth.ToString(), new Vector2(enemy[i].EnemyDisplay.X,
                            enemy[i].EnemyDisplay.Y), Color.White);
                    }

                    for (int i = 0; i < door.Count; i++)
                    {
                        spriteBatch.Draw(door[i].DoorTexture,
                        door[i].DoorRectangle, door[i].DoorColor);
                    }



                    for (int i = 0; i < bullet.Count; i++)
                    {
                        spriteBatch.Draw(bullet[i].BulletTexture,
                        bullet[i].BulletRectangle, bullet[i].BulletColor);

                    }

                    for (int i = 0; i < tiles.Count; i++)
                    {
                        spriteBatch.Draw(tiles[i].TilesTexture,
                        tiles[i].TilesRectangle, tiles[i].TilesColor);

                    }
                    break;

            }



            spriteBatch.End();


            spriteBatch.Begin();

            switch (CurrentGameState)
            {
                case GameState.Playing:

                    //interface
                    spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
                    spriteBatch.DrawString(fontinterface, ": " + ammo.ToString() +"/20 ", new Vector2(100, 100), Color.White);
                    spriteBatch.DrawString(fontinterface, "Health:", new Vector2(20, 20), Color.White);
                    spriteBatch.DrawString(fontinterface, "Score: " + score.ToString(), new Vector2(500, 20), Color.White);
                    spriteBatch.Draw(Content.Load<Texture2D>("guninterface"), new Rectangle(20, 60, 100, 100), Color.White);

                     
                    break;

                case GameState.Level2:

                   
                        spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
                        spriteBatch.DrawString(fontinterface, ": " + ammo.ToString() + "/20 ", new Vector2(100, 100), Color.White);
                        spriteBatch.DrawString(fontinterface, "Health:", new Vector2(20, 20), Color.White);
                        spriteBatch.DrawString(fontinterface, "Score: " + score.ToString(), new Vector2(500, 20), Color.White);
                        spriteBatch.Draw(Content.Load<Texture2D>("guninterface"), new Rectangle(20, 60, 100, 100), Color.White);
               
                    break;

            }



                spriteBatch.End();



            base.Draw(gameTime);
        }

        void PlayAnimation(int reset)
        {
            if (delayplayer > 10)
            {
                if (reset != changeAnim)
                {
                    playerSource.X = 0;
                }
                else
                {
                    if (playerSource.X < playerTexture.Width - playerTexture.Width / 5)
                    {
                        playerSource.X += playerTexture.Width / 5;
                    }
                    else
                    {
                        playerSource.X = 0;
                    }
                }
                delayplayer = 0;
            }
            delayplayer++;
            changeAnim = reset;
        }


    }
}
