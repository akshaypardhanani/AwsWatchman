﻿using System;
using System.Collections.Generic;
using Amazon.CloudWatch.Model;

namespace Watchman.Engine.Generation
{
    public static class MetricAlarmHelper
    {
        public static bool AlarmAndOkActionsAreEqual(MetricAlarm alarm)
        {
            var alarmCount = alarm.AlarmActions?.Count ?? 0;
            var okCount = alarm.OKActions?.Count ?? 0;

            if (alarmCount != okCount)
            {
                return false;
            }

            if (alarmCount == 0)
            {
                return true;
            }

            var allAlarmActions = string.Join(",", alarm.AlarmActions);
            var allOkActions = string.Join(",", alarm.OKActions);

            return string.Equals(allAlarmActions, allOkActions, StringComparison.OrdinalIgnoreCase);
        }
    }
}
