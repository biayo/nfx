/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2017 ITAdapter Corp. Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NFX.Environment;
using NFX.Security;

namespace NFX.Web.Shipping
{
  /// <summary>
  /// Parameters used for connect to API
  /// </summary>
  public class ShippingConnectionParameters : INamed, IConfigurable
  {
    #region Static

      public static TParams Make<TParams>(IConfigSectionNode node)
        where TParams: ShippingConnectionParameters
      {
        return FactoryUtils.MakeAndConfigure<TParams>(node, typeof(TParams), args: new object[] { node });
      }

      public static TParams Make<TParams>(string connStr, string format = Configuration.CONFIG_LACONIC_FORMAT)
        where TParams: ShippingConnectionParameters
      {
        var cfg = Configuration.ProviderLoadFromString(connStr, format).Root;
        return Make<TParams>(cfg);
      }

    #endregion

    #region ctor

    public ShippingConnectionParameters() {}

      public ShippingConnectionParameters(IConfigSectionNode node)
      {
        Configure(node);
      }

      public ShippingConnectionParameters(string connStr, string format = Configuration.CONFIG_LACONIC_FORMAT)
      {
        var conf = Configuration.ProviderLoadFromString(connStr, format).Root;
        Configure(conf);
      }

	  #endregion

    [Config]
    public string Name { get; set; }

    public User User { get; set; }


    public virtual void Configure(IConfigSectionNode node)
    {
      ConfigAttribute.Apply(this, node);
    }
  }
}
