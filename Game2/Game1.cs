using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;
using Game2;

namespace Robot_House_Touhou_Game
{
    public class Game1 : Game
    {
        // Varaibles created
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont basicfont;
        Scrolling scrolling1, scrolling2;
        Vector2 spriteLocation = new Vector2(0, 0);
        Texture2D attackMethod1, attackMethod2, smallball, enemyTexture, playerTexture, bullet_sprite, hitbox, red_dot;
        const int maxEnemies = 150;
        enemy_builder builder = new enemy_builder();
        player player;
        Random random = new Random();
        List<enemy1> enemies = new List<enemy1>();
        List<enemy> test_enemies = new List<enemy>();
        float timer;
        Collisions collide = new Collisions();
        private SpriteFont timerfont, endgame;
        int timecounter = 0, player_speed = 4,shootcounter = 0, i;
        int spawn_count = 0, spawning_point = 50, spawning_point2 = 450, spawning_point3 = 250, spawning_point4 = 250; // Spawn counts
        int index = 50, index2 = 50; // Indexes
        //private SpriteFont timerfont;
        Keys shoot_key = Keys.Space, up_key = Keys.Up, down_key = Keys.Down, right_key = Keys.Right, left_key = Keys.Left;//set it to default first
        const float enemyCreationTimer = .5f;
        // Elapsed time since the last creation of an enemy.
        double elapsedTime = 0;
        Texture2D texture;
        Texture2D life_star;
        XMLFileReader xml_reader = new XMLFileReader();
        List<string> list_enemyID = new List<string>();
        List<int> list_health = new List<int>();
        List<int> list_timecounter = new List<int>();
        List<bool> list_firing = new List<bool>();
        List<int> list_number_of_enemies = new List<int>();
        List<string> list_path = new List<string>();
        List<Vector2> list_starting_Vector = new List<Vector2>();
        List<int> list_repeats = new List<int>();
        int coins = 0;
        List<Vector2> enemy_dying_coordinate = new List<Vector2>();
        List<string> list_bullet_paths = new List<string>();
        List<string> list_bullet_attacks = new List<string>();
        int test_index = 0;

        //game states in the game
        enum GameState
        {
            MainMenu,
            Options,
            Playing,
            Settings,
            GameOver,
            Victory,
        }
        GameState CurrentGameState = GameState.MainMenu;

        ///SCREEN ADJUSTMENTS
        int screenWidth = 640, screenHeight = 480;
        cButton btnPlay;
        settings_button settings;
        up_button up_button_variable;
        down_button down_button_variable;
        right_button right_button_variable;
        left_button left_button_variable;
        private string _stringValue = string.Empty;


        //List of all types of attacks in the game
        List<AttackDecorator> enemy_attacks = new List<AttackDecorator>();
        List<AttackDecorator> boss_attacks = new List<AttackDecorator>();
        List<AttackDecorator> player_attacks = new List<AttackDecorator>();

        public Game1()
        {
            //Game settings
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 640;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        //settings on game activation
        protected override void OnActivated(object sender, System.EventArgs args)
        {
            Window.Title = "Shooter";
            base.OnActivated(sender, args);
        }

        //settings on game deactivation
        protected override void OnDeactivated(object sender, System.EventArgs args)
        {
            Window.Title = "(Paused) Application";
            base.OnActivated(sender, args);

        }

        //initialized variables on runtime
        protected override void Initialize()
        {
            //base variables initialized
            base.Initialize();
            Color[] colorData = new Color[100 * 100];
            Color[] playerColor = new Color[100 * 100];
            Color[] bulletColor = new Color[100 * 100];
            
            hitbox = new Texture2D(this.GraphicsDevice, 5, 5);
            texture = new Texture2D(this.GraphicsDevice, 100, 100);
            Vector2 temp = new Vector2(250, 400);
            player = new player(temp);

            xml_reader.XMLREAD(list_enemyID, list_health, list_timecounter, list_firing, list_number_of_enemies, list_path, list_starting_Vector, list_bullet_paths, list_bullet_attacks);
            //creation of colors in game
            for (int i = 0; i < 10000; i++)
            {
                playerColor[i] = Color.Green;
            }

            for (int i = 0; i < 10000; i++)
            {
                colorData[i] = Color.Red;
            }

            for (int i = 0; i < 10000; i++)
            {
                bulletColor[i] = Color.PapayaWhip;
            }

            //setting the colors to the objects
            hitbox.SetData<Color>(bulletColor);
            base.Initialize();



        }

        //content loaded into the game
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //load up Spritefonts
            life_star = Content.Load<Texture2D>("life_star.png");
            timerfont = Content.Load<SpriteFont>("TimerFont");
            basicfont = Content.Load<SpriteFont>("basicfont");
            endgame = Content.Load<SpriteFont>("EndGame");
            //Menu stuff
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            //loads up textures/sprites
            IsMouseVisible = true;
            btnPlay = new cButton(Content.Load<Texture2D>("button"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(225, 300));//position
            settings = new settings_button(Content.Load<Texture2D>("Settings-Button"), graphics.GraphicsDevice);
            settings.setPosition(new Vector2(60, 60));//position
            up_button_variable = new up_button(Content.Load<Texture2D>("up_button.png"), graphics.GraphicsDevice);
            up_button_variable.setPosition(new Vector2(80,120));//position
            down_button_variable = new down_button(Content.Load<Texture2D>("down_button.png"), graphics.GraphicsDevice);
            down_button_variable.setPosition(new Vector2(150, 120));//position
            left_button_variable = new left_button(Content.Load<Texture2D>("left_button.png"), graphics.GraphicsDevice);
            left_button_variable.setPosition(new Vector2(220, 120));//position      
            right_button_variable = new right_button(Content.Load<Texture2D>("right_button.png"), graphics.GraphicsDevice);

            right_button_variable.setPosition(new Vector2(290, 120));//position
            bullet_sprite = Content.Load<Texture2D>("enemy_bullet.png");
            attackMethod1 = bullet_sprite;
            attackMethod2 = Content.Load<Texture2D>("smallsmall");
            smallball = Content.Load<Texture2D>("smallball");
            enemyTexture = Content.Load<Texture2D>("enemyTexture.png");
            playerTexture = Content.Load<Texture2D>("playerTexture.png");
            red_dot = Content.Load<Texture2D>("red_dot.png");
            scrolling1 = new Scrolling(Content.Load<Texture2D>("background.png"), new Rectangle(0, 0, 640, 960));
            scrolling2 = new Scrolling(Content.Load<Texture2D>("background2.png"), new Rectangle(0, 640, 1000, 480));

        }

        //unloads content
        protected override void UnloadContent()
        {
            timerfont = null;
        }

        //updates the game each tick
        protected override void Update(GameTime gameTime)
        {
            //checks if the the user hits escape. will exit the program
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouse = Mouse.GetState();
          
            //settings for each different game state
            switch (CurrentGameState)
            {
                //Main Menu game state
                case GameState.MainMenu:
                    //if a button is clicked, then game state changes
                    if (btnPlay.isClicked == true)
                    {
                        CurrentGameState = GameState.Playing;
                    }
                    if (settings.isClicked == true)
                    {
                        CurrentGameState = GameState.Settings;
                    }
                    btnPlay.Update(mouse);
                    settings.Update(mouse);
                    timer = 0;
                    elapsedTime = 0;
                    //clears all enemies in the list
                    enemies.Clear();
                    test_enemies.Clear();
                    //clears all attacks on screen
                    enemy_attacks.Clear();
                    boss_attacks.Clear();
                    player_attacks.Clear();
                    enemy_dying_coordinate.Clear();


                    //restarts all counters
                    spawn_count = 0;
                    spawning_point = 50;
                    spawning_point2 = 450;
                    spawning_point3 = 250;
                    spawning_point4 = 250;
                    player.isVisible = true;
                    break;
                case GameState.Playing:
                    break;
                
                //Settings game state
                case GameState.Settings:
                    //Allows for the user to change key bindings
                    if (btnPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    if (settings.isClicked == true) { CurrentGameState = GameState.Settings; }
                    //changes up key
                    if(up_button_variable.isClicked == true)
                    {
                        var keyboardState = Keyboard.GetState();

                        var keys = keyboardState.GetPressedKeys();

                        if (keys.Length > 0)
                        {
                            up_key = keys[0];

                            var keyValue = keys[0].ToString();
                            _stringValue += keyValue;
                        }
                    }
                    //changes down key
                    if (down_button_variable.isClicked == true)
                    {
                        var keyboardState = Keyboard.GetState();

                        var keys = keyboardState.GetPressedKeys();

                        if (keys.Length > 0)
                        {
                            down_key = keys[0];
                            var keyValue = keys[0].ToString();
                            _stringValue += keyValue;
                        }
                    }
                    //changes left key
                    if (left_button_variable.isClicked == true) 
                    {
                        var keyboardState = Keyboard.GetState();

                        var keys = keyboardState.GetPressedKeys();

                        if (keys.Length > 0)
                        {
                            left_key = keys[0];
                            var keyValue = keys[0].ToString();
                            _stringValue += keyValue;
                        }
                    }
                    //changes right key
                    if (right_button_variable.isClicked == true)
                    {
                        var keyboardState = Keyboard.GetState();

                        var keys = keyboardState.GetPressedKeys();

                        if (keys.Length > 0)
                        {
                            right_key = keys[0];
                            var keyValue = keys[0].ToString();
                            _stringValue += keyValue;
                        }
                    }
                    btnPlay.Update(mouse);
                    settings.Update(mouse);
                    up_button_variable.Update(mouse);
                    down_button_variable.Update(mouse);
                    left_button_variable.Update(mouse);
                    right_button_variable.Update(mouse);
                    break;


            }
           
            //Slow down mode
            //checks if the left shift key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                foreach (enemy enemy in this.test_enemies)
                {
                    enemy.speedX = 1;
                    enemy.speedY = 1;
                }

                foreach (enemy1 enemy in this.enemies)
                {
                    enemy.speedX = 1;
                    enemy.speedY = 1;
                }


                foreach (Attacks bullet in this.enemy_attacks)
                {
                    Vector2 temp = new Vector2(0, .5f);
                    bullet.setVelocity(temp);
                }

                player_speed = 2;
            }
            
            //reverts back to normal speed
            if (!Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                foreach (enemy enemy in this.test_enemies)
                {
                    if (enemy.ID == "enemy" || enemy.ID == "enemy" || enemy.ID == "enemy" || enemy.ID == "enemy")
                    {
                        enemy.speedX = 2;
                        enemy.speedY = 2;
                    }

                    else
                    {
                        enemy.speedX = 4;
                        enemy.speedY = 4;
                    }
                }

                foreach (enemy1 enemy in this.enemies)
                {
                    if (enemy.ID == "enemy" || enemy.ID == "enemy" || enemy.ID == "enemy" || enemy.ID == "enemy")
                    {
                        enemy.speedX = 2;
                        enemy.speedY = 2;
                    }

                    else
                    {
                        enemy.speedX = 4;
                        enemy.speedY = 4;
                    }
                }

                foreach (Attacks bullet in this.enemy_attacks)
                {
                    Vector2 temp = new Vector2(0, 1);
                    bullet.setVelocity(temp);
                }

                player_speed = 4;
            }

            //player commands. The player can't move if they are still respawning
            if (player.respawn == false)
            {
                //player moves to the left
                if (!Keyboard.GetState().IsKeyDown(left_key))
                {
                    if (player.get_origin().X + player_speed < 620)
                    {
                        Vector2 temp = new Vector2(player.get_origin().X + player_speed, player.get_origin().Y);
                        player.set_origin(temp);
                    }

                }

                //player moves to the right
                if (!Keyboard.GetState().IsKeyDown(right_key))
                {
                    if (player.get_origin().X - player_speed > 0)
                    {
                        Vector2 temp = new Vector2(player.get_origin().X - player_speed, player.get_origin().Y);
                        player.set_origin(temp);
                    }

                }

                //player moves up
                if (!Keyboard.GetState().IsKeyDown(up_key))
                {
                    if (player.get_origin().Y + player_speed < 460)
                    {
                        Vector2 temp = new Vector2(player.get_origin().X, player.get_origin().Y + player_speed);
                        player.set_origin(temp);
                    }


                }
                
                //player moves down
                if (!Keyboard.GetState().IsKeyDown(down_key))
                {
                    if (player.get_origin().Y - player_speed > 0)
                    {
                        Vector2 temp = new Vector2(player.get_origin().X, player.get_origin().Y - player_speed);
                        player.set_origin(temp);
                    }


                }
            }

            //CHEATING
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                collide.setGodMode();
                Console.WriteLine("should be god mode");
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.C))
            {
                collide.revertGodMode();
                Console.WriteLine("should not be god mode");
            }

            //if player is respawning then the player will move through a set path
            if (player.respawn == true)
            {
                player.update_path();
            }

            //Invincibility
            //player will turn black and have their collision detection turned off
            //will return to normal after a few seconds
            if (player.invincibility == true)
            {
                player.ticker++;
                Color[] playerColor = new Color[100 * 100];
                for (int i = 0; i < 10000; i++)
                {
                    playerColor[i] = Color.Black;
                }


                if (player.ticker == 200)
                {
                    player.invincibility = false;
                    player.ticker = 0;
                    for (int i = 0; i < 10000; i++)
                    {
                        playerColor[i] = Color.Green;
                    }
                }

            }
            
            //Enemy shooting
            //regular enemies shooting normally
            if (shootcounter % 3 == 0)
            {
                foreach (enemy enemy in test_enemies)
                {
                    if ((enemy.firing == true && enemy.ID != "midboss") || (enemy.firing == true && enemy.ID != "boss"))
                    {
                        Shoot(enemy);
                        shootcounter++;
                    }
                }


            }

            //boss attacks with a very weird parabolic attack
            if (shootcounter % 10 == 2) //shoot crazy circle about every 10 seconds
            {
                foreach (enemy enemy in test_enemies)
                {
                    if (enemy.firing == true && enemy.ID == "boss" || enemy.firing == true && enemy.ID == "midboss")
                    {
                        ShootCrazyCircle(enemy);
                        shootcounter++;
                    }
                }

                foreach (enemy enemy in enemies)
                {
                    if (enemy.firing == true && enemy.ID == "boss")
                    {
                        ShootCrazyCircle(enemy);
                        shootcounter++;
                    }

                }
            }

            //shoots all around the boss
            if (shootcounter % 7 == 4 || shootcounter % 7 == 6)
            {
                foreach (enemy enemy in test_enemies)
                {
                    if (enemy.firing == true && enemy.ID == "boss")
                    {
                        ShootFullCircle(enemy);
                        shootcounter++;
                    }

                }
            }

            //midboss shoots half circles
            if (shootcounter % 14 == 1 || shootcounter % 14 == 3 || shootcounter % 14 == 5)
            {
                foreach (enemy enemy in test_enemies)
                {
                    if (enemy.firing == true && enemy.ID == "midboss")
                    {
                        ShootHalfCircle(enemy);
                        shootcounter++;
                    }
                }
            }

            ///midboss shoots full circle
            if (shootcounter % 14 == 7 || shootcounter % 14 == 9 || shootcounter % 14 == 11)
            {
                foreach (enemy enemy in test_enemies)
                {
                    if (enemy.firing == true && enemy.ID == "midboss")
                    {
                        ShootFullCircle(enemy);
                        shootcounter++;
                    }
                }
            }

            //removes dead enemies from the enemy list
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].finished == true)
                {
                    enemies.RemoveAt(i--);
                }
            }

            for (int i = 0; i < test_enemies.Count; i++)
            {
                if (test_enemies[i].finished == true)
                {
                    test_enemies.RemoveAt(i--);
                }
            }
            if(player_attacks.Count > 200)
            {
                player_attacks.RemoveAt(0);
            }
            //updates game time
            this.elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (test_index < list_timecounter.Count && this.elapsedTime >= enemyCreationTimer && timecounter > list_timecounter[test_index])
            {
                Vector2 temp = list_starting_Vector[test_index];

                if (list_path[test_index] == "-1")
                {
                    int x = random.Next(0, 600);
                    temp.X = x;
                    list_starting_Vector[test_index] = temp;
                    builder.attach_path6(temp);
                }

                else if (list_path[test_index] == "1")
                {
                    builder.attach_path1(temp);
                }

                else if (list_path[test_index] == "2")
                {
                    builder.attach_path2(temp);
                }

                else if (list_path[test_index] == "3")
                {
                    temp.X = spawning_point;
                    list_starting_Vector[test_index] = temp;
                    spawning_point = spawning_point + 50;
                    builder.attach_path3(temp);
                }

                else if (list_path[test_index] == "4")
                {
                    builder.attach_path4(temp);
                }

                else if (list_path[test_index] == "5")
                {
                    builder.attach_path5(temp);
                }

                else if (list_path[test_index] == "6")
                {
                    builder.attach_path6(temp);
                }

                else if (list_path[test_index] == "7")
                {
                    builder.attach_path7(temp);
                }

                else if (list_path[test_index] == "8")
                {
                    builder.attach_path8(temp);
                }

                else if (list_path[test_index] == "midboss")
                {
                    builder.attach_midboss(temp);
                }

                else if (list_path[test_index] == "boss")
                {
                    builder.attach_stage1(temp);
                }

                this.test_enemies.Add(builder.Build(list_enemyID[test_index], list_health[test_index], list_firing[test_index], list_starting_Vector[test_index], list_bullet_paths[test_index], list_bullet_attacks[test_index]));
                this.elapsedTime = 0;
                spawn_count++;

                if (spawn_count == list_number_of_enemies[test_index])
                {
                    spawn_count = 0;
                    test_index++;
                }

            

            if (spawn_count == list_number_of_enemies[0])
                {
                    spawn_count = 0;
                    test_index++;
                }

            }

            if (timecounter > 120)
            {
                bool win = true;
                foreach (enemy enemy in test_enemies)
                {
                    if (enemy.ID == "boss")
                    {
                        win = false;
                    }

                    if (win == true)
                    {
                        CurrentGameState = GameState.Victory;
                    }

                    else
                    {
                        win = true;
                    }
                }
            }

            //updates all enemy movements
            foreach (enemy1 enemy in this.enemies)
            {
                if (enemy.isVisible == true)
                {
                    enemy.update_path(gameTime, timecounter);
                }
            }

            foreach (enemy_with_movement enemy in this.test_enemies)
            {
                if (enemy.isVisible == true)
                {
                    enemy.update_path(gameTime, timecounter);
                }
            }
            //updates timers and counters
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timecounter += (int)timer;
            shootcounter += (int)timer;
            if (timer >= 1.0F) timer = 0F;

            //Player has no more llife
            //Game state goes to game over and timers/ lives are reset
            if (player.getlife() == 0)
            {
                //OUT OF LIFE
                CurrentGameState = GameState.GameOver;
                btnPlay.isClicked = false;
                btnPlay.Update(mouse);

                enemies.Clear();
                test_enemies.Clear();
                enemy_attacks.Clear();
                boss_attacks.Clear();
                player_attacks.Clear();
                player.setlife(3);
                timer = 0;//reset timer after you click the button
                timecounter = 0;

            }

            //Manual shooting
            if (Keyboard.GetState().IsKeyDown(shoot_key))
            {
                if(player.isVisible)
                {
                    PlayerShoot(player);
                }
                
            }
            
            //update all enemy attacks
            updateAttacks();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ////collision detection
            foreach (AttackDecorator attackDecorator in enemy_attacks)
            {
                collide.Collide(attackDecorator, player);
            }

            //collision detection between player shots and enemies, adds coins when enemies die
            foreach (enemy enemy in test_enemies)
            {
                foreach (AttackDecorator attackDecorator in player_attacks)
                {
                    if (collide.Collide(test_enemies, enemy, attackDecorator))
                    {
                           enemy_dying_coordinate.Add(new Vector2(enemy.get_origin().X, enemy.get_origin().Y));//i have to center the picture
                    }
                }

                collide.Collide(enemy, player);
            }

            foreach (AttackDecorator attackDecorator in boss_attacks)
            {
                collide.Collide(attackDecorator, player);
            }

            foreach (enemy1 enemy in enemies)
            {
                foreach (AttackDecorator attackDecorator in player_attacks)
                {
                    if (collide.Collide(enemies, enemy, attackDecorator))
                    {
                        enemy_dying_coordinate.Add(new Vector2(enemy.get_origin().X, enemy.get_origin().Y));//i have to center the picture
                    }
                }

                collide.Collide(enemy, player);
            }

            for (int i = 0; i < enemy_dying_coordinate.Count; i++)
            {
                if (collide.Collide((enemy_dying_coordinate[i]), player))//collide with powerups
                 {
                    //TODO remove the power ups
                    enemy_dying_coordinate.RemoveAt(i);
                    coins++;
                }
            }
            if (coins > 10)
            {
                player.setlife(player.getlife() + 1);
                coins = 0;

            }




            foreach (AttackDecorator attackDecorator in enemy_attacks)
            {
                collide.Collide(attackDecorator, player);
            }
            if (scrolling1.rectangle.Y + scrolling1.texture.Height > 0) scrolling1.rectangle.Y = 0;
            scrolling1.Update();
            scrolling1.Update();

            //foreach (Attacks bullet in boss_attacks)
            //{
            //    player.Collide(bullet, player);
            //}

            //foreach (enemy enemy in enemies)
            //{
            //    player.Collide(enemy, player);
            //}

            //foreach (AttackDecorator bullet in player_attacks)
            //{
            //    foreach (enemy enemy in test_enemies)
            //    {
            //        collide.Collide(test_enemies, enemy, bullet);
            //    }
            //}
            base.Update(gameTime);
        }

        //update attack function
        //update movements for all projectiles
        public void updateAttacks()
        {
            for(int i = 0; i < enemy_dying_coordinate.Count; i ++)
            {
                Vector2 coin = enemy_dying_coordinate[i];
                enemy_dying_coordinate.RemoveAt(i);
                coin.Y += 1;
                enemy_dying_coordinate.Insert(i, coin); 
                
            }
            foreach (Attacks projectile in enemy_attacks)
            {
                projectile.Update(); //Unique update function
            }
            //foreach (Attacks attack in enemy_attacks)
            //{
            //    attack.Draw(spriteBatch, enemy_attacks, player);
            //}

            foreach (Attacks projectile in boss_attacks)
            {
                projectile.Update(); //Unique update function
            }

            foreach (AttackDecorator projectile in player_attacks)
            {
                projectile.Update(); //Unique update function

            }
            for (int c = 0; c < enemy_attacks.Count; c++)
            {
                if (enemy_attacks[c].isVisible == false)
                {
                    enemy_attacks.RemoveAt(c--);
                }
            }

            for (int c = 0; c < player_attacks.Count; c++)
            {
                if (player_attacks[c].isVisible == false)
                {
                    player_attacks.RemoveAt(c--);
                }
            }

            for (int c = 0; c < boss_attacks.Count; c++)
            {
                if (boss_attacks[c].isVisible == false)
                {
                    boss_attacks.RemoveAt(c--);
                }
            }
        }

        //shooting functions
        public void Shoot(enemy enemy)
        {
            //SHOOT BULLET -- with decorator everything will work like this
            /* ALL ATTACK TYPES
            // single bullet shooting straight down */

            if (enemy.ID == "midboss" || enemy.ID == "boss")
            {
                int temp = random.Next(1, 5);

                if (temp == 1)
                {
                    enemy_attacks.Add(new StraightDownPath(new SingleBulletAttack(smallball, enemy.get_origin())));
                }

                else if (temp == 2)
                {
                    //player attack
                    enemy_attacks.Add(new StraightUpPath(new PlayerSingleAttack(smallball, enemy.get_origin())));
                }

                else if (temp == 3)
                {
                    //half circle straight down
                    enemy_attacks.Add(new StraightDownPath(new HalfCircleAttack(smallball, 5, enemy.get_origin())));
                }

                else if (temp == 4)
                {
                    //Collapsing attack spinning
                    enemy_attacks.Add(new CollapsingCirclePath(new CircBulletAttack(smallball, 20, enemy.get_origin())));
                }
                else
                {
                    //full circle spinning 
                    enemy_attacks.Add(new FullCirclePath(new CircBulletAttack(smallball, 20, enemy.get_origin())));

                }

                //CrazyPath spinning
                enemy_attacks.Add(new CrazyPath(new CrazyAttack(smallball, 50, enemy.get_origin())));
            }

            Attacks enemyAttack;
            if (enemy.ID == "enemy")
            {
                if (enemy.bullet_attack == "CircBulletAttack")
                {
                    enemyAttack = new CircBulletAttack(smallball, 20, enemy.get_origin());
                }

                else if (enemy.bullet_attack == "CrazyAttack")
                {
                    enemyAttack = new CrazyAttack(smallball, 50, enemy.get_origin());
                }

                else if (enemy.bullet_attack == "HalfCircleAttack")
                {
                    enemyAttack = new HalfCircleAttack(smallball, 5, enemy.get_origin());
                }

                else if (enemy.bullet_attack == "PlayerSingleAttack")
                {
                    enemyAttack = new PlayerSingleAttack(bullet_sprite, 1, enemy.get_origin());
                }
                else if (enemy.bullet_attack == "SingleBulletAttack")
                {
                    enemyAttack = new SingleBulletAttack(bullet_sprite, 1, enemy.get_origin());
                }
                else if (enemy.bullet_attack == "TrackerAttack")
                {
                    enemyAttack = new TrackerAttack(smallball, enemy.get_origin(), player.get_origin());
                }
                else
                {
                    enemyAttack = new SingleBulletAttack(smallball, 1, enemy.get_origin());
                }

                //Tracker Path
                AttackDecorator enemyAttackPath;
                if (enemy.bullet_path == "CollapsingCirclePath")
                {
                    enemyAttackPath = new CollapsingCirclePath(enemyAttack);
                }

                else if (enemy.bullet_path == "CrazyPath")
                {
                    enemyAttackPath = new CrazyPath(enemyAttack);
                }

                else if (enemy.bullet_path == "FullCirclePath")
                {
                    enemyAttackPath = new FullCirclePath(enemyAttack);
                }

                else if (enemy.bullet_path == "StraightDownPath")
                {
                    enemyAttackPath = new StraightDownPath(enemyAttack);
                }

                else if (enemy.bullet_path == "TrackerPath")
                {
                    enemyAttackPath = new TrackerPath(enemyAttack);
                }
                else
                {
                    enemyAttackPath = new StraightDownPath(enemyAttack);
                }

                enemy_attacks.Add(enemyAttackPath);
            }
            //Tracker Path
            //enemy_attacks.Add(new TrackerPath(new TrackerAttack(smallball, enemy.get_origin(), player.get_origin())));


            //Attacks newAttack2 = new Bullet(smallball, enemy.get_origin());
            //enemy_attacks.Add(newAttack2);
        }

        public void PlayerShoot(player player)
        {
            Vector2 temp = player.get_origin();
            temp.X += 14;
            temp.Y += 10;
            
            player_attacks.Add(new StraightUpPath(new PlayerSingleAttack(bullet_sprite, 1, temp)));
        }

        public void ShootFullCircle(enemy enemy)
        {
            boss_attacks.Add(new FullCirclePath(new CircBulletAttack(smallball, 15, enemy.get_origin())));
        }
        public void ShootCrazyCircle(enemy enemy)
        {
            boss_attacks.Add(new FullCirclePath(new CrazyAttack(smallball, 100, enemy.get_origin())));
        }
        public void ShootHalfCircle(enemy enemy)
        {
            boss_attacks.Add(new StraightDownPath(new HalfCircleAttack(smallball, 5, enemy.get_origin())));
        }


        /// This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //background
            scrolling1.Draw(spriteBatch);
            scrolling1.Draw(spriteBatch);
            //draws each of the enemies in the list of enemies
            foreach (enemy enemy in this.test_enemies)
            {
                if (enemy.isVisible == true)
                {
                    this.spriteBatch.Draw(enemyTexture, enemy.get_origin());
                }

            }

            foreach (enemy enemy in this.enemies)
            {
                if (enemy.isVisible == true)
                {
                    this.spriteBatch.Draw(enemyTexture, enemy.get_origin());
                }

            }
            Vector2 temp = player.get_origin();
            temp.X += 18;
            temp.Y += 18;

            //draws the player
            if (player.isVisible)
            {
                this.spriteBatch.Draw(playerTexture, player.get_origin());
                this.spriteBatch.Draw(hitbox, temp);
            }

            spriteBatch.End();

            //draws the attacks
            foreach (AttackDecorator attack in enemy_attacks)
            {
                attack.Draw(spriteBatch, player);
                
            }

            foreach (AttackDecorator attack in boss_attacks)
            {
                attack.Draw(spriteBatch, player);
            }

            foreach (AttackDecorator attack in player_attacks)
            {
                attack.Draw(spriteBatch, player);
            }

            //draws the counters
            spriteBatch.Begin();
            spriteBatch.DrawString(timerfont, timecounter.ToString(), new Vector2(25, 25), Color.White);
            spriteBatch.DrawString(basicfont, "Life:" + player.getlife() + "Coins:" + coins, new Vector2(25, 50), Color.White);
            spriteBatch.DrawString(basicfont, collide.godModeEnabled , new Vector2(25, 70), Color.Crimson);
            //Drawing stars
            int new_star_coordinate = 3;
            for(int i = 0; i < player.getlife(); i++)spriteBatch.Draw(life_star, new Rectangle(new_star_coordinate+=50, 3, 40, 40), Color.White);

            for (int i = 0; i < enemy_dying_coordinate.Count; i++)
            {
                //TODO: now add in a new item
                
                spriteBatch.Draw(red_dot, enemy_dying_coordinate[i], Color.White);
            }

            //draws different text and backgrounds based on game states
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    settings.Draw(spriteBatch);
                    btnPlay.Draw(spriteBatch);
                    timecounter = 0;
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        CurrentGameState = GameState.Playing;
                    }
                    break;
                case GameState.Playing:
                    break;
                case GameState.Settings:
                    spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    settings.Draw(spriteBatch);
                    up_button_variable.Draw(spriteBatch);
                    down_button_variable.Draw(spriteBatch);
                    left_button_variable.Draw(spriteBatch);
                    right_button_variable.Draw(spriteBatch);
                    btnPlay.Draw(spriteBatch);
                    if (up_button_variable.isClicked == true)
                    {
                        spriteBatch.DrawString(basicfont, "Press A key for the up button:", new Vector2(200, 200), Color.White);
                        spriteBatch.DrawString(basicfont, "you pressed" + _stringValue, new Vector2(200, 550), Color.White);
                    }
                    if (down_button_variable.isClicked == true)
                    {
                        spriteBatch.DrawString(basicfont, "Press A key for the down button:", new Vector2(200, 200), Color.White);
                        spriteBatch.DrawString(basicfont, "you pressed" + _stringValue, new Vector2(200, 550), Color.White);
                    }
                    if (left_button_variable.isClicked == true)
                    {
                        spriteBatch.DrawString(basicfont, "Press A key for the left button:", new Vector2(200, 200), Color.White);
                        spriteBatch.DrawString(basicfont, "you pressed" + _stringValue, new Vector2(200, 550), Color.White);
                    }
                    if (right_button_variable.isClicked == true)
                    {
                        spriteBatch.DrawString(basicfont, "Press A key for the right button:", new Vector2(200, 200), Color.White);
                        spriteBatch.DrawString(basicfont, "you pressed" + _stringValue, new Vector2(200, 550), Color.White);
                    }
                    //code that should be displayed after you clicked settings
                    break;
                case GameState.GameOver:
                    spriteBatch.DrawString(endgame, "Game Over\n Hit enter to return to menu", new Vector2(50, 150), Color.White);
                    player.isVisible = false;
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        CurrentGameState = GameState.MainMenu;
                    }
                    break;
                case GameState.Victory:
                    spriteBatch.DrawString(endgame, "Victory\n Hit enter to return to menu", new Vector2(50, 150), Color.White);
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        CurrentGameState = GameState.MainMenu;
                    }
                    break;


            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    

    
}