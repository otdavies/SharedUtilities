
using Psyfer.Patterns;
using Psyfer.Utilities;
using UnityEngine;

// IN PROGRESS

public class Quadtree
{
    public struct Region
    {
        private Vector2 _center;
        public Vector2 Center { get => _center; private set => _center = value; }

        private float _size;
        public float Size { get => _size; private set => _size = value; }

        private bool _isSplit;
        public bool IsSplit { get => _isSplit; private set => _isSplit = value; }

        public Region(Vector2 center, float size)
        {
            _center = center;
            _size = size;
            _isSplit = false;
        }

        public bool Contains(Vector2 point)
        {
            bool withinXBounds = point.x >= Center.x - Size / 2 && point.x <= Center.x + Size / 2;
            bool withinYBounds = point.y >= Center.y - Size / 2 && point.y <= Center.y + Size / 2;
            return withinXBounds && withinYBounds;
        }

        public Region[] Split()
        {
            Region[] regions = new Region[4];
            regions[0] = new Region(new Vector2(Center.x - Size / 2, Center.y - Size / 2), Size / 2);
            regions[1] = new Region(new Vector2(Center.x + Size / 2, Center.y - Size / 2), Size / 2);
            regions[2] = new Region(new Vector2(Center.x - Size / 2, Center.y + Size / 2), Size / 2);
            regions[3] = new Region(new Vector2(Center.x + Size / 2, Center.y + Size / 2), Size / 2);
            return regions;
        }
    }

    private int _maxLevels = 5;
    private int _pointsPerBucket = 1;
    private Option<Region>[] _regions;

    public Quadtree(Region region, int maxLevels, int maxObjects)
    {
        this._maxLevels = maxLevels;
        this._pointsPerBucket = maxObjects;
        this._regions = new Option<Region>[4.Pow(maxLevels)];
        this._regions[0] = new Option<Region>(region);
    }
}
