﻿using System;
using Trinity.Framework;
using System.Windows.Forms;
using System.Windows.Media;
using Trinity.Framework.Objects;

namespace Trinity.UI.Visualizer.RadarCanvas
{
    /// <summary>
    /// OnRender doesnt like creating Brushes, Pens etc; this class allows us to pre-create and reuse them.
    /// Overlaps with system Brushes/Pens becausse they are read-only so they cannot have their properties modified. eg. Opacity.
    /// </summary>
    public static class RadarResources
    {
        private static SolidColorBrush _NodeP9;
        private static SolidColorBrush _nodeP8;
        private static SolidColorBrush _nodeP7;
        private static SolidColorBrush _nodeP6;
        private static SolidColorBrush _nodeP5;
        private static SolidColorBrush _nodeP4;
        private static SolidColorBrush _nodeP3;
        private static SolidColorBrush _nodeP2;
        private static SolidColorBrush _nodeP1;
        public static SolidColorBrush BlankNode;
        public static SolidColorBrush BackTrackNode;
        private static SolidColorBrush _nodeN2;
        private static SolidColorBrush _nodeN1;
        private static SolidColorBrush _Node0;


        public class ResourceSet
        {
            public SolidColorBrush Brush;
            public Pen Pen;
        }

        // I dont know what they're doing in the Brushes resource but its probably returning a new object from a color.
        // This is bad, very bad for performance. Use a fixed resource like these brushes below.
        internal static readonly SolidColorBrush BlueBrush = Brushes.Blue;
        internal static readonly SolidColorBrush SkyBlueBrush = Brushes.DeepSkyBlue;
        internal static readonly SolidColorBrush OrangeRedBrush = Brushes.OrangeRed;
        internal static readonly SolidColorBrush RedBrush = Brushes.DarkRed;
        internal static readonly SolidColorBrush GreenBrush = Brushes.Green;
        internal static readonly SolidColorBrush BlackBrush = Brushes.Black;
        internal static readonly SolidColorBrush DarkGrayBrush = Brushes.DarkGray;
        internal static readonly SolidColorBrush LimeGreenBrush = Brushes.LimeGreen;
        internal static readonly SolidColorBrush HotPinkBrush = Brushes.HotPink;
        internal static readonly SolidColorBrush OrangeBrush = Brushes.Orange;
        internal static readonly SolidColorBrush YellowBrush = Brushes.Yellow;

        static RadarResources()
        {
            Node0 = new SolidColorBrush(Colors.DarkGray);
            NodeA = new SolidColorBrush(Colors.Green);
            NodeB = new SolidColorBrush(ControlPaint.Light(System.Drawing.Color.Green, 5).ToMediaColor());
            NodeC = new SolidColorBrush(ControlPaint.Light(System.Drawing.Color.Green, 10).ToMediaColor());
            NodeD = new SolidColorBrush(ControlPaint.Light(System.Drawing.Color.Green, 20).ToMediaColor());
            //NodeA = new SolidColorBrush(ControlPaint.Light(System.Drawing.Color.Green, 25).ToMediaColor());
            //NodeB = new SolidColorBrush(ControlPaint.Light(System.Drawing.Color.Green, 50).ToMediaColor());
            //NodeC = new SolidColorBrush(ControlPaint.Light(System.Drawing.Color.Green, 75).ToMediaColor());
            //NodeD = new SolidColorBrush(ControlPaint.Light(System.Drawing.Color.Green, 100).ToMediaColor());


            WalkableTerrainBorder = new Pen(Brushes.NavajoWhite, 0.3);

            CurrentPathPen1 = new Pen(Brushes.Yellow, 3);
            CurrentPathPen2 = new Pen(Brushes.LightYellow, 3);


            RangeGuidePen = new Pen(Brushes.LightYellow, 0.1);
            TransparentBrush = new SolidColorBrush(Colors.Transparent);
            BorderPen = new Pen(Brushes.Black, 0.1);
            GridPen = new Pen(Brushes.Black, 0.1);

            AvoidanceBrush = new SolidColorBrush(Colors.OrangeRed);
            AvoidanceTextBrush = new SolidColorBrush(Colors.DarkOrange);
            AvoidanceLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(AvoidanceBrush.Color.ToDrawingColor(), 75).ToMediaColor()), 2);

            GreyBrush = new SolidColorBrush(Colors.DarkGray);
            GreyPen = new Pen(GreyBrush, 1);

            BlackPen = new Pen(BlackBrush, 2);

            ActorDefaultBrush = new SolidColorBrush(Colors.White);

            PlayerBrush = new SolidColorBrush(Colors.White);

            OtherPlayerBrush = new SolidColorBrush(Colors.Beige);

            SuccessPen = new Pen(new SolidColorBrush(Colors.LawnGreen), 3)
            {
                DashStyle = DashStyles.DashDotDot,
                DashCap = PenLineCap.Round
            };

            FailurePen = new Pen(new SolidColorBrush(Colors.OrangeRed), 3)
            {
                DashStyle = DashStyles.Dash,
                DashCap = PenLineCap.Round
            };


            PlayerLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(PlayerBrush.Color.ToDrawingColor(), 50).ToMediaColor()), 1);

            ItemBrush = new SolidColorBrush(Colors.DarkSeaGreen);
            ItemLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(ItemBrush.Color.ToDrawingColor(), 50).ToMediaColor()), 1);

            SafeBrush = new SolidColorBrush(Colors.ForestGreen)
            {
                Opacity = 0.5
            };

            WalkedTerrain = new SolidColorBrush(Color.FromRgb(100, 220, 165))
            {
                Opacity = 0.7
            };

            SelectionBrush = new SolidColorBrush(Colors.Yellow)
            {
                Opacity = 0.5,
            };

            SelectionPen = new Pen(SelectionBrush, 2)
            {
                DashStyle = DashStyles.DashDotDot,
                DashCap = PenLineCap.Flat
            };

            BuffedRegionBrush = new RadialGradientBrush
            {
                RadiusX = 0.25,
                RadiusY = 0.25,
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.Transparent, 0),
                    new GradientStop(Color.FromArgb(50, 144, 238, 144), 0.5),
                    new GradientStop(Color.FromArgb(75, 124, 252, 0), 1),
                }
            };

            BuffedRegionPen = new Pen(SelectionBrush, 2)
            {
                DashStyle = DashStyles.DashDotDot,
                DashCap = PenLineCap.Flat
            };

            BlacklistedBrush = new SolidColorBrush(Colors.Red);

            BlacklistedPen = new Pen(BlacklistedBrush, 2)
            {
                DashStyle = DashStyles.Dot,
                DashCap = PenLineCap.Flat
            };

            TargetPen = new Pen(Brushes.MediumPurple, 3);
            Target = Brushes.MediumPurple;

            SafeBrushLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(SafeBrush.Color.ToDrawingColor(), 50).ToMediaColor()), 1);

            ProjectilePen = new Pen(new SolidColorBrush(Colors.IndianRed), 3);
            
            EliteBrush = new SolidColorBrush(Colors.DarkGoldenrod);
            EliteLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(EliteBrush.Color.ToDrawingColor(), 50).ToMediaColor()), 2);

            SceneFrameInclude = new Pen(new SolidColorBrush(Colors.LightGreen), 2)
            {
                DashStyle = DashStyles.Dot,
                DashCap = PenLineCap.Square
            };

            SceneFrameExclude = new Pen(new SolidColorBrush(Colors.OrangeRed), 2)
            {
                DashStyle = DashStyles.Dot,                
                DashCap = PenLineCap.Square
            };

            HostileUnitBrush = new SolidColorBrush(Colors.DodgerBlue);
            HostileUnitLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(HostileUnitBrush.Color.ToDrawingColor(), 50).ToMediaColor()), 1);

            UnitBrush = new SolidColorBrush(Colors.LightSkyBlue);
            UnitLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(UnitBrush.Color.ToDrawingColor(), 50).ToMediaColor()), 1);

            TransparentBrush = new SolidColorBrush(Colors.Transparent);
            TransparentPen = new Pen(TransparentBrush, 2);

            LabelBrush = new SolidColorBrush(Colors.White);

            GizmoBrush = new SolidColorBrush(Colors.Yellow);
            GizmoLightPen = new Pen(new SolidColorBrush(ControlPaint.Light(GizmoBrush.Color.ToDrawingColor(), 50).ToMediaColor()), 1);

            WhiteDashPen = new Pen(new SolidColorBrush(Colors.WhiteSmoke), 2)
            {
                DashStyle = DashStyles.DashDotDot,
                DashCap = PenLineCap.Flat
            };

            OrangeDashPen = new Pen(new SolidColorBrush(Colors.Orange), 1)
            {
                DashStyle = DashStyles.DashDotDot,
                DashCap = PenLineCap.Flat
            };

            LineOfSightPen = new Pen(new SolidColorBrush(Colors.Yellow), 2);


            LineOfSightLightBrush = new SolidColorBrush(ControlPaint.Light(Colors.Yellow.ToDrawingColor(), 75).ToMediaColor())
            {
                Opacity = 0.6
            };

            BacktrackNodePen = new Pen(new SolidColorBrush(Colors.Yellow), 0.2);

            BackTrackNode = new SolidColorBrush(Colors.Yellow)
            {
                Opacity = 0.15,
            };

            LineOfSightLightPen = new Pen(LineOfSightLightBrush, 2);

            Background = new SolidColorBrush(Color.FromRgb(51, 51, 51))
            {
                Opacity = 1
            };

            UsedGizmoBrush = new SolidColorBrush(Colors.Yellow)
            {
                Opacity = 0.5,
            };

            UsedGizmoPen = new Pen(UsedGizmoBrush, 2)
            {
                DashStyle = DashStyles.DashDotDot
            };

            WalkableTerrain = new SolidColorBrush(Colors.LightSlateGray)
            {
                Opacity = 0.2
            };

            WalkedTerrain = new SolidColorBrush(Color.FromRgb(100, 220, 165))
            {
                Opacity = 0.7
            };

            _Node0 = new SolidColorBrush(Color.FromRgb(150, 150, 150))
            {
                Opacity = 1
            };

            _NodeP9 = new SolidColorBrush(Color.FromRgb(255, 0, 0))
            {
                Opacity = 1
            };

            _nodeP8 = new SolidColorBrush(Color.FromRgb(255, 25, 0))
            {
                Opacity = 1
            };

            _nodeP7 = new SolidColorBrush(Color.FromRgb(255, 51, 1))
            {
                Opacity = 1
            };

            _nodeP6 = new SolidColorBrush(Color.FromRgb(255, 76, 1))
            {
                Opacity = 1
            };

            _nodeP5 = new SolidColorBrush(Color.FromRgb(255, 102, 0))
            {
                Opacity = 1
            };

            _nodeP4 = new SolidColorBrush(Color.FromRgb(255, 127 , 0))
            {
                Opacity = 1
            };
            _nodeP3 = new SolidColorBrush(Color.FromRgb(255, 153, 0))
            {
                Opacity = 1
            };

            _nodeP2 = new SolidColorBrush(Color.FromRgb(255, 192, 0))
            {
                Opacity = 1
            };

            _nodeP1 = new SolidColorBrush(Color.FromRgb(255, 228, 0))
            {
                Opacity = 1
            };

            _nodeN1 = new SolidColorBrush(Color.FromRgb(45, 142, 79))
            {
                Opacity = 1
            };

            _nodeN2 = new SolidColorBrush(Color.FromRgb(27, 142, 32))
            {
                Opacity = 1
            };

            BlankNode = new SolidColorBrush(Colors.Transparent);
        }

        public static SolidColorBrush Node0 { get; set; }

        public static SolidColorBrush NodeD { get; set; }

        public static SolidColorBrush NodeC { get; set; }

        public static SolidColorBrush NodeB { get; set; }

        public static SolidColorBrush NodeA { get; set; }

        public static RadialGradientBrush BuffedRegionBrush { get; set; }

        public static Pen BuffedRegionPen { get; set; }

        public static Pen BlackPen { get; set; }

        public static SolidColorBrush AvoidanceTextBrush { get; set; }

        public static Pen ProjectilePen { get; set; }

        public static SolidColorBrush BlacklistedBrush { get; set; }

        public static Pen BlacklistedPen { get; set; }

        public static Pen SelectionPen { get; set; }

        public static Brush GetWeightedBrush(int current, float currentPct)
        {

            /*
             * 	maroon	#800000	(128,0,0)
 	            dark red	#8B0000	(139,0,0)
 	            brown	#A52A2A	(165,42,42)
 	            firebrick	#B22222	(178,34,34)
 	            crimson	#DC143C	(220,20,60)
 	            red	#FF0000	(255,0,0)
 	            tomato	#FF6347	(255,99,71)
 	            coral	#FF7F50	(255,127,80)
             */

            if(current < 1)
                return _Node0;

            if (Math.Abs(current) < float.Epsilon)
                return TransparentBrush;                        

            if (currentPct >= 0.8)
            {
                return _NodeP9;
            }

            if (currentPct >= 0.7)
            {
                return _nodeP8;
            }

            if (currentPct >= 0.6)
            {
                return _nodeP7;
            }

            if (currentPct >= 0.5)
            {
                return _nodeP6;
            }

            if (currentPct >= 0.4)
            {
                return _nodeP5;
            }

            if (currentPct >= 0.3)
            {
                return _nodeP4;
            }

            if (currentPct >= 0.2)
            {
                return _nodeP3;
            }

            if (currentPct >= 0.1)
            {
                return _nodeP2;
            }

            if (currentPct >= 0.001)
            {
                return _nodeP1;
            }

            if (current < -4)
            {
                return _nodeN2;
            }

            //if (current < 1)
            //{
            //    return _nodeN1;
            //}



            //if (current >= 8)
            //{
            //    return _Node9;
            //}

            //if (current >= 7)
            //{
            //    return _node8;
            //}

            //if (current >= 6)
            //{
            //    return _node7;
            //}

            //if (current >= 5)
            //{
            //    return _node6;
            //}

            //if (current >= 4)
            //{
            //    return _node5;
            //}

            //if (current >= 3)
            //{
            //    return _node4;
            //}

            //if (current >= 2)
            //{
            //    return _node3;
            //}

            //if (current >= 1)
            //{
            //    return _node2;
            //}

            //if (current >= 0)
            //{
            //    return _node1;
            //}

            return BlankNode;
        }



        /// <summary>
        /// Returns a base color for actor based on type and stuff
        /// </summary>
        public static ResourceSet GetActorResourceSet(RadarObject radarObject)
        {
            ResourceSet res = new ResourceSet();
            res.Brush = ActorDefaultBrush;

            try
            {
                switch (radarObject.Actor.Type)
                {
                    case TrinityObjectType.Avoidance:
                        res.Brush = AvoidanceBrush;
                        res.Pen = AvoidanceLightPen;
                        break;

                    case TrinityObjectType.Portal:
                    case TrinityObjectType.Container:
                    case TrinityObjectType.CursedChest:
                    case TrinityObjectType.CursedShrine:
                    case TrinityObjectType.Shrine:
                    case TrinityObjectType.HealthWell:
                    case TrinityObjectType.Interactable:
                    case TrinityObjectType.Barricade:
                    case TrinityObjectType.Destructible:
                        res.Brush = GizmoBrush;
                        res.Pen = GizmoLightPen;
                        break;

                    case TrinityObjectType.ProgressionGlobe:
                    case TrinityObjectType.PowerGlobe:
                    case TrinityObjectType.HealthGlobe:
                    case TrinityObjectType.Gold:
                    case TrinityObjectType.Item:
                        res.Brush = ItemBrush;
                        res.Pen = ItemLightPen;
                        break;

                    case TrinityObjectType.Player:
                        res.Brush = PlayerBrush;
                        res.Pen = PlayerLightPen;
                        break;

                    case TrinityObjectType.Unit:

                        if (radarObject.Actor.IsElite)
                        {
                            res.Brush = EliteBrush;
                            res.Pen = EliteLightPen;
                        }
                        else if (radarObject.Actor.IsHostile)
                        {
                            res.Brush = HostileUnitBrush;
                            res.Pen = HostileUnitLightPen;
                        }                            
                        else
                            res.Brush = UnitBrush;
                            res.Pen = UnitLightPen;
                        break;

                    default:
                        res.Brush = TransparentBrush;
                        res.Pen = TransparentPen;
                        break;
                }

                if (radarObject.Actor.IsBlacklisted)
                    res.Pen = BlacklistedPen;

            }
            catch (Exception ex)
            {
                Core.Logger.Log("Exception in RadarUI.GetActorColor(). {0} {1}", ex.Message, ex.InnerException);
            }
            return res;
        }

        public static Brush WalkableTerrain { get; set; }

        public static Brush WalkedTerrain { get; set; }

        public static SolidColorBrush GizmoBrush { get; set; }

        public static SolidColorBrush UsedGizmoBrush { get; set; }

        public static SolidColorBrush TransparentBrush { get; set; }

        public static Pen RangeGuidePen { get; set; }

        public static Pen BorderPen { get; set; }

        public static Pen GridPen { get; set; }

        public static Pen GreyPen { get; set; }

        public static Pen WhiteDashPen { get; set; }

        public static Pen OrangeDashPen { get; set; }

        public static Pen UsedGizmoPen { get; set; }

        public static Pen LineOfSightPen { get; set; }

        public static SolidColorBrush LabelBrush { get; set; }

        public static Pen CurrentPathPen1 { get; set; }

        public static Pen CurrentPathPen2 { get; set; }

        public static Pen HighlightPen { get; set; }

        public static SolidColorBrush AvoidanceBrush { get; set; }

        public static SolidColorBrush ActorDefaultBrush { get; set; }

        public static SolidColorBrush ItemBrush { get; set; }

        public static SolidColorBrush PlayerBrush { get; set; }

        public static SolidColorBrush OtherPlayerBrush { get; set; }

        public static SolidColorBrush SelectionBrush { get; set; }

        public static SolidColorBrush EliteBrush { get; set; }

        public static SolidColorBrush HostileUnitBrush { get; set; }

        public static SolidColorBrush UnitBrush { get; set; }

        public static Pen AvoidanceLightPen { get; set; }

        public static Pen EliteLightPen { get; set; }

        public static Pen HostileUnitLightPen { get; set; }

        public static Pen BacktrackNodePen { get; set; }

        public static Pen UnitLightPen { get; set; }

        public static Pen GizmoLightPen { get; set; }

        public static Pen TransparentPen { get; set; }

        public static Pen ItemLightPen { get; set; }

        public static Pen PlayerLightPen { get; set; }

        public static Brush GreyBrush { get; set; }

        public static SolidColorBrush SafeBrush { get; set; }

        public static Pen SafeBrushLightPen { get; set; }

        public static Pen LineOfSightLightPen { get; set; }

        public static SolidColorBrush LineOfSightLightBrush { get; set; }

        public static SolidColorBrush Background { get; set; }

        public static Pen TargetPen { get; set; }

        public static SolidColorBrush Target { get; set; }

        public static Pen WalkableTerrainBorder { get; set; }

        public static Pen SuccessPen { get; set; }
        public static Pen FailurePen { get; set; }
        public static Pen MarkerPen { get; set; } = new Pen(Brushes.Orange, 1);
        public static Pen SceneFrameInclude { get; set; }
        public static Pen SceneFrameExclude { get; set; }
        public static Pen SceneConnectionPen { get; set; } = new Pen(Brushes.GreenYellow, 1);
    }
}
