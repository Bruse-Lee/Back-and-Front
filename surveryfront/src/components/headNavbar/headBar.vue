<template>
  <div>
    <!--  下拉菜单-->
    <el-dropdown @command="handleCommand" class="drop"
      ><!--  绑定指令,在methods里定义-->
      <span class="el-dropdown-link">
        <span class="uName"
          >您好:&nbsp;&nbsp;&nbsp;&nbsp;{{ showUsername }}</span
        >
        <i class="el-icon-arrow-down el-icon--right"></i>
      </span>
      <div></div>
      <el-dropdown-menu slot="dropdown">
        <!-- icon是修改图标 ，command是点击后传给方法的值-->
        <el-dropdown-item icon="el-icon-edit" command="edit"
          >>修改密码</el-dropdown-item
        >

        <el-dropdown-item icon="el-icon-s-operation" command="quit"
          >>退出登录</el-dropdown-item
        >
      </el-dropdown-menu>
    </el-dropdown>
    <!--  下拉菜单结束-->
    <!-- 注销 -->
    <el-dialog
      title="Tips"
      :visible.sync="centerDialogVisible"
      width="25%"
      center
    >
      <label class="logout">确定注销?</label>
      <span slot="footer" class="dialog-footer">
        <el-button @click="handleCancel">取 消</el-button>
        <el-button type="primary" @click="handleConfirm">确 定</el-button>
      </span>
    </el-dialog>
    <!-- 注销结束 -->
    <!-- 修改密码 -->
    <el-dialog
      title="密码修改"
      :visible.sync="changeDialogVisible"
      width="25%"
      center
    >
      <span slot="footer" class="dialog-footer">
        <el-form
          :model="dataForm"
          label-width="80px"
          :rules="dataFormRules"
          ref="dataForm"
          :size="size"
          label-position="right"
        >
          <el-form-item label="旧密码" prop="oldpassword">
            <el-input
              v-model="dataForm.oldpassword"
              type="password"
              auto-complete="off"
            ></el-input>
          </el-form-item>
          <el-form-item label="新密码" prop="newpassword">
            <el-input
              v-model="dataForm.newpassword"
              type="password"
              auto-complete="off"
            ></el-input>
          </el-form-item>
        </el-form>
        <el-button @click="handleCancel">取 消</el-button>
        <el-button type="primary" @click="handleChange">修改</el-button>
      </span>
    </el-dialog>
    <!-- 修改密码结束 -->
  </div>
</template>


<script>
import { changePassword } from "../../api/user";
import Cookies from "js-cookie";
import { removeToken } from '../../utils/auth'
export default {
  data() {
    return {
      username: null,
      centerDialogVisible: false,
      changeDialogVisible: false,
      size: "small",
      dataForm: {
        oldpassword: "",
        newpassword: "",
      },
      //设置属性
      dataFormRules: {
        oldpassword: [
          { required: true, message: "请输入旧密码", trigger: "blur" },
        ],
        newpassword: [
          { required: true, message: "请输入新密码", trigger: "blur" },
        ],
      },
    };
  },

  inject: ["reload"],
  methods: {
    handleCommand(command) {
      switch (command) {
        case "edit":
          console.log("修改密码");
          this.changeDialogVisible = true;
          break;
        case "quit": {
          console.log("退出登录");
          this.centerDialogVisible = true;
          break;
        }
      }
    },
    handleConfirm() {
      removeToken()
      this.$router.push("/Login");
    },
    handleChange() {
      // let nowPassword = Cookies.get('password');
      // console.log(nowPassword);
      // if (
      //   this.dataForm.oldpassword != nowPassword ||
      //   this.dataForm.newpassword > 0
      // ) {
      //   this.$message.error("原密码不一致,请确认后重试");
      // } else {

        this.$refs.dataForm.validate((valid) => {
          if (valid) {
            this.$confirm("确认修改吗?", "提示", {}).then(() => {
              let params = {
                
                newpassword:this.dataForm.newpassword,
                currentPassword:this.dataForm.oldpassword
              };
              // let id = params.id;
              console.log(params);
              
              changePassword(params).then((res) => {
                console.log(res);
              });
            });
          }
        });
      // }
    },
    handleCancel() {
      this.changeDialogVisible = false;
      this.centerDialogVisible = false;
    },
  },
  computed: {
    showUsername() {

      return Cookies.get("username");
    },
  },
};
</script>

<style scoped>
.uName {
  font-family: fantasy;
  font-size: 15px;
}

.el-dialog--center .el-dialog__body {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>