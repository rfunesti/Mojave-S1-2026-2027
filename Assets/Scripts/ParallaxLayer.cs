using System.Threading.Tasks;
using UnityEngine;

public class Parallax
{
    public enum Layer
    {
        Foreground, Midground, Background
    }
    public static float speed = 2f;
    

    public static float GetSpeed(Layer layer)
    {
        switch (layer)
        {
            case Layer.Foreground:                
                return speed * 1f;
            case Layer.Midground:                
                return speed * 0.5f;
            case Layer.Background:
                return speed * 0.1f;
            default:
                return speed * 1;
        }
    }
}
    public class ParallaxLayer : MonoBehaviour
    {
        public Transform[] tiles;
        public float left = -19f;
        public Vector3 right = new Vector3(19f, 0f, 0f);
        public Parallax.Layer layer;

        void Update()
        {
       
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].position += Vector3.left * Time.deltaTime *  Parallax.GetSpeed(layer);

                // Tile has gone too far to the left <-
                if (tiles[i].position.x <= left)
                {
                    // Reset tile position to the right ->
                    tiles[i].position = right;
                }
            }
        }
    }
