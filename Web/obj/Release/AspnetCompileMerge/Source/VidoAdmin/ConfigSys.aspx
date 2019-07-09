<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigSys.aspx.cs" Inherits="Maticsoft.Web.VidoAdmin.ConfigSys" %>

<link rel="stylesheet" type="text/css" href="style.css" />

<table width="100%" border="0" style="margin-bottom: 8px;">
    <tr>
        <td align="left" valign="top">
            <h2>网站基本信息设置</h2>
            <table id="rounded-corner" style="width: 100%;">
                <thead>
                    <tr>
                        <th width="16%" align="left" valign="middle">项目</th>
                        <th width="34%" align="left" valign="middle">参数</th>
                        <th width="50%" align="center" valign="middle">说明</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="odd">
                        <td height="33" align="left" valign="middle">网站状态</td>
                        <td align="left" valign="middle">
                            <select name="ConfigValue" title="网站状态">
                                <option value="运行">运行</option>
                                <option value="停止">停止</option>
                            </select>
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip">此项设置为停止后，对前端页面的访问请求都将转到信息提示页</span></td>
                    </tr>
                    <tr class="even">
                        <td height="33" align="left" valign="middle">网站名称</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="网站名称" />
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip">本信息可显示在网站页面、标题栏等文本区域</span></td>
                    </tr>
                    <tr class="odd">
                        <td height="33" align="left" valign="middle">PC端首页网址</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="PC端首页网址" />
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip">首页网址是网站重要的访问入口，基于本管理系统的管理，网址以HTTP://开头，结尾不含/</span></td>
                    </tr>
                    <tr class="even">
                        <td height="33" align="left" valign="middle">移动端首页网址</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="移动端首页网址" />
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip">用于手机、平板电脑访问的入口</span></td>
                    </tr>
                    <tr class="odd">
                        <td height="33" align="left" valign="middle">管理系统网址</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="管理系统网址" />
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip">本管理系统的访问网址，以HTTP://开头，结尾不含/</span></td>
                    </tr>
                    <tr class="even">
                        <td height="33" align="left" valign="middle">搜索关键词上榜阀值</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="搜索关键词上榜阀值" />
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip">达到阀值后，搜索关键词将显示在前端搜索页面醒目处</span></td>
                    </tr>
                    <tr class="even">
                        <td height="33" align="left" valign="middle">站长QQ号码</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="站长QQ号码" />
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip"></span></td>
                    </tr>
                    <tr class="odd">
                        <td height="33" align="left" valign="middle">群管QQ号码</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="群管QQ号码" />
                        </td>
                        <td align="left" valign="middle"></td>
                    </tr>
                    <tr class="odd">
                        <td height="33" align="left" valign="middle">群管QQ号码2</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="群管QQ号码2" />
                        </td>
                        <td align="left" valign="middle"></td>
                    </tr>
                    <tr class="odd">
                        <td height="33" align="left" valign="middle">群管QQ号码3</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="群管QQ号码3" />
                        </td>
                        <td align="left" valign="middle"></td>
                    </tr>
                    <tr class="even">
                        <td height="33" align="left" valign="middle">客服QQ号码</td>
                        <td align="left" valign="middle">
                            <input name="ConfigValue" type="text" class="form_input" placeholder="客服QQ号码" />
                        </td>
                        <td align="left" valign="middle"></td>
                    </tr>
                    <tr class="odd">
                        <td height="33" align="left" valign="middle">留言板审核机制</td>
                        <td align="left" valign="middle">
                            <select name="ConfigValue" title="留言板审核机制">
                                <option value="开启">开启</option>
                                <option value="关闭">关闭</option>
                            </select>
                        </td>
                        <td align="left" valign="middle"><span class="ConfigTip">如此项设置为开启，对于未回复的留言将不予在前端页面显示</span></td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
</table>

