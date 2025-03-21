﻿/*
 * Copyright (c) Facebook, Inc. and its affiliates.
 *
 * This source code is licensed under the license found in the
 * LICENSE file in the root directory of this source tree.
 */

using com.facebook.witai.lib;

namespace com.facebook.witai.data
{
    public class WitIntValue : WitValue
    {
        public override object GetValue(WitResponseNode response)
        {
            return GetIntValue(response);
        }

        public override bool Equals(WitResponseNode response, object value)
        {
            int iValue = 0;
            if (value is int i)
            {
                iValue = i;
            }
            else if (null != value && !int.TryParse("" + value, out iValue))
            {
                return false;
            }

            return GetIntValue(response) == iValue;
        }

        public int GetIntValue(WitResponseNode response)
        {
            return Reference.GetIntValue(response);
        }
    }
}
