import { MenuItem } from '@yoyo/theme';

// 全局的左侧导航菜单
export class AppMenus {
    static Menus = [
        // 首页
        new MenuItem(
            'HomePage',
            '',
            'anticon anticon-home',
            '/app/home'
        ),
        new MenuItem(
            '系统管理',
            '',
            'anticon anticon-setting',
            '',
            [
                // 租户
                new MenuItem(
                    'Tenants',
                    'Pages.Tenants',
                    'anticon anticon-team',
                    '/app/tenants',
                ),
                // 角色
                new MenuItem(
                    'Roles',
                    'Pages.Roles',
                    'anticon anticon-safety',
                    '/app/roles',
                ),
                // 用户
                new MenuItem(
                    'Users',
                    'Pages.Users',
                    'anticon anticon-user',
                    '/app/users',
                ),
            ]
        ),

    ];
}