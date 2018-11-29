import { AppMenus } from './AppMenus';
import { Component, OnInit } from '@angular/core';
import { SignalRAspNetCoreHelper } from '@shared/helpers/SignalRAspNetCoreHelper';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import { Injector } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { SettingsService, TitleService, MenuService, MenuItem } from '@yoyo/theme';
import { Router } from '@angular/router';
import { NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { HostBinding } from '@angular/core';
import { NzModalService, NzNotificationService } from 'ng-zorro-antd';
import { AppConsts } from '@shared/AppConsts';

@Component({
  selector: 'app-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less'],
})
export class AppComponent extends AppComponentBase
  implements OnInit, AfterViewInit {
  @HostBinding('class.layout-fixed')
  get isFixed() {
    return this.settings.layout.fixed;
  }
  @HostBinding('class.layout-boxed')
  get isBoxed() {
    return this.settings.layout.boxed;
  }
  @HostBinding('class.aside-collapsed')
  get isCollapsed() {
    return this.settings.layout.collapsed;
  }

  // 全局的菜单
  Menums = [
    // 首页
    new MenuItem('主页', '', 'anticon anticon-home', '/app/home'),
    // 系统管理
    new MenuItem(
      '系统管理',
      '',
      'anticon anticon-setting',
      '',
      [
        //租户
        new MenuItem(
          '租户管理',
          'Pages.Tenants',
          '',
          '/app/tenants',
        ),
        // 角色
        new MenuItem(
          '角色管理',
          'Pages.Roles',
          '',
          '/app/roles',
        ),
        // 用户
        new MenuItem(
          '用户管理',
          'Pages.Users',
          '',
          '/app/users',
        )
      ]
    )
  ];

  constructor(
    injector: Injector,
    private settings: SettingsService,
    private router: Router,
    private titleSrv: TitleService,
    private menuService: MenuService,
  ) {
    super(injector);

    // 创建菜单
    this.menuService.menus = AppMenus.Menus;
  }

  ngOnInit(): void {
    this.router.events
      .pipe(filter(evt => evt instanceof NavigationEnd))
      .subscribe(() => this.titleSrv.setTitle('ABP信息化平台'));

    // 注册通知信息
    // SignalRAspNetCoreHelper.initSignalR();
    // 触发通知事件
    // abp.event.on('abp.notifications.received', userNotification => {
    //   abp.notifications.showUiNotifyForUserNotification(userNotification);

    //   // Desktop notification
    //   Push.create('AbpZeroTemplate', {
    //     body: userNotification.notification.data.message,
    //     icon: abp.appPath + 'assets/app-logo-small.png',
    //     timeout: 6000,
    //     onClick: function () {
    //       window.focus();
    //       this.close();
    //     },
    //   });
    // });
  }

  ngAfterViewInit(): void {
    // ($ as any).AdminBSB.activateAll();
    // ($ as any).AdminBSB.activateDemo();
  }
}
