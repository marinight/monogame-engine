using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine;

public class Sprite {
    public Texture2D texture;
    public Rectangle sourceRect;
    public Rectangle rect;
    public Vector2 origin;
    
    public Vector2 position = Vector2.Zero;
    public Vector2 velocity = Vector2.Zero;
    public Vector2 acceleration = Vector2.Zero;
    public float angle = 0;
    Color color = Color.White;

    public bool flipX{
        get{return _flipX == SpriteEffects.FlipHorizontally;}
        set{
            if (value)
                _flipX = SpriteEffects.FlipHorizontally;
            else _flipX = SpriteEffects.None;
        }
    }

    public bool flipY{
        get{return _flipY == SpriteEffects.FlipVertically;}
        set{
            if (value)
                _flipY = SpriteEffects.FlipVertically;
            else _flipY = SpriteEffects.None;
        }
    }

    private SpriteEffects _flipX=0;
    private SpriteEffects _flipY=0;

    public Sprite(float x, float y, string sprite) {
        texture = Files.GetTexture(sprite);
        position = new Vector2(x,y);
        sourceRect = new Rectangle(0,0, texture.Width, texture.Height);
        rect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        origin = new Vector2(texture.Width / 2, texture.Height / 2); 
    }

    public virtual void Update(float elapsed) {
        position += velocity * elapsed;
        velocity += acceleration * elapsed;
        rect.X=(int)position.X;
        rect.Y=(int)position.Y;
    }
    public void Draw() {
        Main.instance._spriteBatch.Draw(texture, rect, sourceRect, color, angle, origin, _flipX | _flipY, 1);
        
    }

    public void Resize(int newWidth, int newHeight) {
        rect.Width=newWidth;
        rect.Height=newHeight;
    }

    public void ResizeSourceRect(int newX, int newY, int newWidth, int newHeight) {
        sourceRect = new Rectangle(newX, newY, newWidth, newHeight);
    }

    public void ChangeOrigin(float newX, float newY) {
        origin.X=newX;
        origin.Y=newY;
    }

    public void ChangeColorByRGB(byte r, byte g, byte b, byte a) {
        color = new Color(r,g,b,a);
    }
    public void ChangeColorByHex(uint hex) {
        color = new Color(hex);
    }
    
}