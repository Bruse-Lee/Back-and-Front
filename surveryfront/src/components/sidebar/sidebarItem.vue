<template>
  <div>
    <!-- <div v-for="menu in menus" :key="menu.path">
      <el-submenu
        v-if="menu.children && menu.children.length > 0"
        :index="menu.path"
      >
        <template slot="title">
          <i class="el-icon-location"></i>
          <span>{{ meun.title }}</span>
        </template>
        <el-menu-item-group>
          <el-menu-item>{{ menu.title }}</el-menu-item>
        </el-menu-item-group>
        <el-submenu v-for="child in menu.children" :key="child.path">
          <template slot="title">{{ child.title }}</template>
          <el-submenu>
            <template slot="title">{{ child.title }}</template>
            <ul>
              <el-menu-item>
                <i class="el-icon-menu"></i>
                <span slot="title">{{ child.title }}</span>
              </el-menu-item>
            </ul>
          </el-submenu>
        </el-submenu>
      </el-submenu>

      <el-menu-item v-else :index="menu.path">
        <span slot="title">{{ menu.title }}</span>
      </el-menu-item>
    </div> -->
    <div v-for="menu in menus" :key="menu.path">
      <el-submenu
        v-if="menu.children && menu.children.length > 0"
        :index="menu.path"
      >
        <template slot="title">
          <i class="el-icon-location"></i>
          <span>{{ menu.title }}</span>
        </template>
        <!-- 嵌套使用组件 -->
        <sidebar-item :menus="menu.children"></sidebar-item>
      </el-submenu>
      <el-menu-item v-else :index="menu.path">
        <span slot="title">{{ menu.title }}</span>
      </el-menu-item>
    </div>
  </div>
</template>

<script>
export default {
  name: "sidebarItem",
  props: {
    menus: {
      type: Array,
      require: true,
    },
  },
};
</script>