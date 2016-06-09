﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficManager.Util {
	public interface IObserver<in T> {
		void OnUpdate(T value);
	}
}
