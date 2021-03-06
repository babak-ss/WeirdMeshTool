﻿using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WeirdMeshTool
{
    public static class DrawShape
    {
        private static Vector3[] segmentsPoints;
        private static Vector3[] segmentsCenterPoints;

        public static Vector3[] SetUpPoints(Shape shape)
        {
            // setting up segment points
            segmentsPoints = new Vector3[shape.SegmentsCount];
            for (int i = 0; i < segmentsPoints.Length; i++)
            {
                segmentsPoints[i] = new Vector3(MathUtility.rCos(shape.Radius, i * (360f / shape.SegmentsCount)),
                                                MathUtility.rSin(shape.Radius, i * (360f / shape.SegmentsCount)),
                                                0);
            }

            // setting up segment's default center points
            segmentsCenterPoints = new Vector3[shape.SegmentsCount];
            for (int i = 0; i < segmentsCenterPoints.Length; i++)
            {
                if (i == segmentsCenterPoints.Length - 1)
                    segmentsCenterPoints[i] = new Vector3((segmentsPoints[i].x + segmentsPoints[0].x) / 2,
                                                          (segmentsPoints[i].y + segmentsPoints[0].y) / 2,
                                                          0);
                else
                    segmentsCenterPoints[i] = new Vector3((segmentsPoints[i].x + segmentsPoints[i + 1].x) / 2,
                                                          (segmentsPoints[i].y + segmentsPoints[i + 1].y) / 2,
                                                          0);
            }

            // apply segment T
            float alpha = 0f;
            for (int i = 0; i < segmentsCenterPoints.Length; i++)
            {
                alpha = (180 / shape.SegmentsCount) + (i * (360 / shape.SegmentsCount));
                segmentsCenterPoints[i] = segmentsCenterPoints[i] + new Vector3(MathUtility.rCos(shape.SegmentsT, alpha), 
                                                                                MathUtility.rSin(shape.SegmentsT, alpha), 
                                                                                0);
            }

            // setup line
            int pointsCount = segmentsPoints.Length + segmentsCenterPoints.Length;
            Vector3[] mainPoints = new Vector3[pointsCount];
            for (int i = 0, j = 0; i < mainPoints.Length; i += 2, j++)
            {
                mainPoints[i] = segmentsPoints[j];
                mainPoints[i + 1] = segmentsCenterPoints[j];
            }
            
            return mainPoints;
        }
    }
}
