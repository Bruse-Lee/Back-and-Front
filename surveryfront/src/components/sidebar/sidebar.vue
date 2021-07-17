<template>
  <!-- <el-scrollbar> -->
    <el-menu
      default-active="1"
      class="el-menu-vertical-demo"
      background-color="black"
      text-color="#dff9fb"
      active-text-color="#fffa65"
      router
      :collapse="collapse"
      
    >
      <sidebarItem :menus="menus"></sidebarItem>
      
    </el-menu>
  <!-- </el-scrollbar> -->
</template>

<script>
import sidebarItem from "../sidebar/sidebarItem.vue";
export default {
  components: {
    sidebarItem,
  },
  props: {
    menus: {
      type: Array,
      require: true,
    },
    collapse: {
      type: Boolean,
      default: false,
    },
  },
};
</script>

<style scoped>
.el-menu {
  height: 100vh;
  text-align: center;
  border-right: none;
}
.profile-details{
  position: fixed;
  bottom: 0;
  width: 260px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  background: #1d1b31;
  padding: 6px 0;
  transition: all 0.5s ease;
}

.profile-details {
  background: none;
}
.profile-details {
  width: 78px;
}
.profile-details .profile-content {
  display: flex;
  align-items: center;
}
.profile-details img {
  height: 52px;
  width: 52px;
  object-fit: cover;
  border-radius: 16px;
  margin: 0 14px 0 12px;
  background: #1d1b31;
  transition: all 0.5s ease;
}
.profile-details img {
  padding: 10px;
}
.profile-details .profile_name,
.profile-details .job {
  color: #fff;
  font-size: 18px;
  font-weight: 500;
  white-space: nowrap;
}
.profile-details i,
.profile-details .profile_name,
.profile-details .job {
  display: flex;
}
.profile-details .job {
  font-size: 15px;
}
</style>