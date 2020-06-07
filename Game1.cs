using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;

namespace Fourier
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlottingGraph circualarGraph,linearGraph;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            IsMouseVisible = true;
            circualarGraph = new PlottingGraph(new Vector2(50, 50), new Vector2(150, 150));
            linearGraph = new PlottingGraph(new Vector2(0, 200), new Vector2(graphics.PreferredBackBufferWidth, 150));


            List<Vector2> f1 = new List<Vector2>();
            List<Vector2> f1Circular = new List<Vector2>();

            float pointIncrement = 0.001f;
            float duration = 2;
            float frequency = 3;
            float increment = (float)(2 * Math.PI * frequency);

            for (float a = 0; a <= duration * 2 * Math.PI; a += increment)
                for(float value = a; value <= a + increment;value += pointIncrement)
                {
                    f1.Add(new Vector2(value, (float)Math.Cos(value)));
                   // f1Circular.Add(new Vector2((float)Math.Cos(value), (float)Math.Sin(value)));
                }

            for(float i = 0,a = 0; i < f1.Count; i++,a+= pointIncrement)
            {
                int index = (int)i;
                
                f1Circular.Add(new Vector2((float)Math.Cos(a),(float)Math.Sin(a)));
            }



                //  circualarGraph.Plot(new PlotLine(f1Circular, Color.Red));
            linearGraph.Plot(new PlotLine(f1, Color.Green));
            circualarGraph.Plot(new PlotLine(f1Circular, Color.Red));

        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Primitives.point = new Texture2D(GraphicsDevice, 1, 1);
            Primitives.point.SetData<Color>(new Color[] { Color.White });
            MyraEnvironment.Game = this;
            var grid = new Grid
            {
                RowSpacing = 8,
                ColumnSpacing = 8
            };

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            
            var button = new TextButton
            {
                GridColumn = 0,
                GridRow = 1,
                Text = "Show"
            };

            button.Click += (s, a) =>
            {
                var messageBox = Dialog.CreateMessageBox("Message", "Some message!");
                messageBox.ShowModal();
            };

            grid.Widgets.Add(button);


            Desktop.Root = grid;
        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Desktop.Render();
            spriteBatch.Begin();


            circualarGraph.Draw(spriteBatch);
            linearGraph.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
