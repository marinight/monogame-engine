using System;
using System.Collections;
using System.Collections.Generic;

namespace Engine;

public class Scene {
    public List<Sprite> sprites;
    public static Scene currentScene;
    public Scene() {
        sprites = new List<Sprite>{};
    }
    public void Add(Sprite s) {
        sprites.Add(s);
    }

    public void Remove(Sprite s) {
        sprites.Remove(s);
    }
    public virtual void Create() {
    }

    public virtual void Update(float elapsed) {
        sprites.ForEach(delegate(Sprite s) {
            s?.Update(elapsed);
        });
    }

    public void Draw() {
        sprites.ForEach(delegate(Sprite s) {
            s?.Draw();
        });
    }
}