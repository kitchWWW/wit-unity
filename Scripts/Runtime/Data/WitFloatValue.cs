﻿/*
 * Copyright (c) Facebook, Inc. and its affiliates.
 *
 * This source code is licensed under the license found in the
 * LICENSE file in the root directory of this source tree.
 */

using System;
using com.facebook.witai.lib;
using UnityEngine;

namespace com.facebook.witai.data
{
    public class WitFloatValue : WitValue
    {
        [SerializeField] public float equalityTolerance = .0001f;

        public override object GetValue(WitResponseNode response)
        {
            return GetFloatValue(response);
        }

        public override bool Equals(WitResponseNode response, object value)
        {
            float fValue = 0;
            if (value is float f)
            {
                fValue = f;
            }
            else if(null != value && !float.TryParse("" + value, out fValue))
            {
                return false;
            }

            return Math.Abs(GetFloatValue(response) - fValue) < equalityTolerance;
        }

        public float GetFloatValue(WitResponseNode response)
        {
            return Reference.GetFloatValue(response);
        }
    }
}
