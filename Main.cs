using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoSound;

namespace Engine;

public class Main : Game
{
    public GraphicsDeviceManager _graphics;
    public SpriteBatch _spriteBatch;
    public Scene scene;

    public static Main instance;

    // public static ContentManager ContentRef;
    // public static SpriteBatch SpriteBatchRef;



    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        instance = this;
        MonoSoundLibrary.Init();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        scene = new GameScene(); // REPLACE THIS WITH AN INSTANCE OF YOUR FIRST SCENE 
        Scene.currentScene = scene;
        scene.Create();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Input.Update();
        scene.Update((float)gameTime.ElapsedGameTime.Milliseconds / 1000);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        scene.Draw();

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    protected override void OnExiting(object sender, EventArgs args) {
        MonoSoundLibrary.DeInit();
    }
}
