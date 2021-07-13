<template>
  <div>
    <div v-for="menu in menus" :key="menu.path">
      <el-submenu
        v-if="menu.children && menu.children.length > 0"
        :index="menu.path"
      >
        <template slot="title">
          <i class="el-icon-location"></i>
          <span>{{ menu.title }}</span>
        </template>

        <sidebar-item :menus="menu.children"></sidebar-item>

        <!-- <el-menu-item-group v-for="child in menu.children" :key="child.path">
          <el-menu-item>{{ child.title }}</el-menu-item>
        </el-menu-item-group>
        <el-submenu v-for="menu in menus" :key="menu.path">
          <template slot="title">{{ menu.title }}</template>
          <el-submenu>
            <template slot="title">{{ child.title }}</template>
            <ul>
              <el-menu-item>
                <i class="el-icon-menu"></i>
                <span slot="title">{{ child.title }}</span>
              </el-menu-item>
            </ul>
          </el-submenu>
        </el-submenu> -->
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