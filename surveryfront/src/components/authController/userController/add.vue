<template>
  <div>
    <el-dialog
      :title="title"
      :visible.sync="addUserVisible"
      width="55%"
      :before-close="handleCancel"
      :close-on-click-modal="false"
      @open="openAddUser()"
    >
      <el-form
        label-position="right"
        label-width="100px"
        :inline="true"
        :model="userInfo"
        :rules="rules"
        ref="user"
        style="padding: 0px 70px 0px 10px"
        class="demo-ruleForm"
      >
        <el-form-item label="用户名" prop="Username">
          <el-input
            v-model="userInfo.Username"
            
            @keyup.native="btKeyUpUsername"
            clearable
            placeholder="请输入用户名"
          ></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="Password">
          <el-input
            type="Password"
            v-model="userInfo.Password"
            placeholder="请输入用户密码"
            autocomplete="off"
            clearable
          ></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="onSubmit('user')">创建用户</el-button>
        <el-button @click="resetForm('user')">重置信息</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
export default {
  name: "AddUser",
  props: {
    addUserVisible: Boolean,
    data: [Object, Boolean],
    title: String,
  },
  data() {
    var validatePass = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请输入密码"));
      }
      callback();
    };
    // var validatePass2 = (rule, value, callback) => {
    //     if (value === '') {
    //         callback(new Error('请再次输入密码'));
    //     } else if (value !== this.userInfo.Password) {
    //         callback(new Error('两次输入密码不一致!'));
    //     } else {
    //         callback();
    //     }
    // };
    // var checktel = (rule, value, callback) => {
    //     if (!value || value === "") {
    //         return callback(new Error('手机号码不能为空'));
    //     }
    //     if (!(/^1[3|4|5|7|8|9][0-9]\d{4,8}$/.test(value))) {
    //         callback(new Error('请输入合法的手机号码'));
    //     } else {
    //         callback();
    //     }
    // };
    // var checkidentity = (rule, value, callback) => {
    //     if (!value || value === "") {
    //         return callback(new Error('身份证号不能为空'));
    //     }
    //     if (!(/^[1-9]\d{5}(18|19|20|(3\d))\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$/.test(value))) {
    //         callback(new Error('请输入合法的身份证号码'));
    //     } else {
    //         callback();
    //     }
    // };
    return {
      userInfo: {
        // userId: '',
        Username: "",
        // realName: '',
        // identity: '',
        // sex: '1',
        // address: '',
        // phone: '',
        // position: '',
        // roleId: '1',
        // roleName: '',
        // userStatus: '1',
        Password: "",
        // checkPassword: ''
      },
      rules: {
        Username: [
          { required: true, message: "请输入用户名", trigger: "blur" },
          {
            min: 3,
            max: 10,
            message: "长度在 3 到 10 个字符",
            trigger: "blur",
          },
        ],
        Password: [
          { required: true, validator: validatePass, trigger: "blur" },
        ],
        // checkPassword: [
        //     {required: true, validator: validatePass2, trigger: 'blur'}
        // ],
        // realName: [
        //     {required: true, message: '请输入真实名字', trigger: 'blur'},
        //     {min: 3, max: 20, message: '长度在 3 到 20 个字符', trigger: 'blur'}
        // ],
        // identity: [
        //     {required: true, validator: checkidentity, trigger: 'blur'}
        // ],
        // address: [
        //     {required: true, message: '请输入家庭地址', trigger: 'blur'}
        // ],
        // phone: [
        //     {required: true, validator: checktel, trigger: 'blur'},
        // ],
        // position: [
        //     {required: true, message: '请输入职业称谓', trigger: 'blur'}
        // ]
      },
    };
  },
  methods: {
    openAddUser() {
      this.$nextTick(function () {
        this.$refs["user"].resetFields();
        for (var key in this.entity) {
          if (this.entity.hasOwnProperty.call(key)) {
            this.entity[key] = "";
          }
        }
      });
    },
    // 禁止输入特殊字符
    btKeyUpUsername(e) {
      e.target.value = e.target.value.replace(
        /[`~!#$%^&*()_=<>?:"{}|~！#￥%……&*（）={}|《》？：“”【】、；‘’，。、\s+]/g,
        ""
      );
      // this.inspectionRecord.description = e.target.value;
    },
    //关闭弹窗
    handleCancel() {
      this.$refs["user"].resetFields();
      this.$emit("cancel");
    },
    onSubmit(formName) {
      let formData = this.userInfo;
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$emit("val-change", formData);
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    // checkUsername() {
    //   let app = this;
    //   let data = {
    //     Username: app.userInfo.Username,
    //   };
    //   app.$Api.checkUsername(data, function (result) {
    //     if (result.result == "false") {
    //       app.$notify({
    //         title: "温馨提示：",
    //         message: result.message,
    //         type: "warning",
    //       });
    //       app.userInfo.Username = "";
    //     }
    //   });
    // },
  },
};
</script>

<style scoped>
</style>