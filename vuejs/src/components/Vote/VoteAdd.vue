<template>
    <div>
        <el-alert
            title="准备发起一个新的在线投票..."
            type="info"
            description="1. 介绍本次投票的主题; 2. 输入提供选择的选项; 3、点击发布！"
            close-text="知道了"
            show-icon>
        </el-alert>
        <br><br>
        <el-steps :active="active" align-center finish-status="success" style="width: 100%;padding:0px 10px;">
            <el-step title="选择主题" icon="el-icon-edit"></el-step>
            <el-step title="输入选项" icon="el-icon-upload"></el-step>
            <el-step title="点击发布" icon="el-icon-picture"></el-step>
        </el-steps>

        <el-form ref="form" :model="form" label-width="80px" style="width:50%;margin: 35px auto;">
        <el-form-item label="投票名称" v-show="display[0]">
            <el-input v-model="form.name"></el-input>
        </el-form-item>
            <el-form-item label="活动时间" v-show="display[0]">
                <el-col :span="11">
                <el-date-picker type="datetime" placeholder="截至日期" v-model="form.date1" style="width: 100%;"></el-date-picker>
                </el-col>
            </el-form-item>
            
            <el-form-item label="详情介绍" v-if="display[0]">
                <el-input type="textarea" v-model="form.desc"></el-input>
            </el-form-item>
            <el-button style="margin-top: 12px;" @click="next" size="small" v-if="display[0]" >下一步 --></el-button>
            

            <el-form-item 
                v-for="(domain, index) in form.items"
                :label="'选项 ' + (index + 1) + ':'"
                :key="index"
                :prop="'form.'+ index + '.value'" v-if="display[1]"
            >
                <el-input v-model="domain.value" v-show="display[1]" style="width: 75%;"></el-input>&nbsp;&nbsp;
                <el-button @click.prevent="removeDomain(domain)" v-show="display[1]">删除</el-button>
            </el-form-item>

            <el-form-item v-if="display[1]">
                <!-- <el-button @click.prevent="removeDomain(form.items)">删除</el-button> -->
                <el-button @click="addDomain" size="small">添加选项</el-button>
                <el-button style="margin-top: 12px;" @click="next" size="small" v-if="butNext">下一步</el-button>
            </el-form-item>

            <el-form-item v-if="display[2]">
                <el-button  @click="Publish" type="success">点击发布</el-button>
            </el-form-item>
        </el-form>

        
        <!-- <el-button style="margin-top: 12px;" @click="next" size="small" v-if="butNext">下一步</el-button> -->
    </div>
</template>

<script>
export default {
    name: 'voteAdd',
    data(){
        return {
            ItemId: 0,
            Title: '测试',
            Statue: true,
            Items: ['选项一','选项二','选项三' , '选项四', '选项五'],
            ItemsNum: [23,25, 42, 12,19],
            ItemCountNum: 0,
            UserName: 'cc',
            StopTime: "",

            active: 0,

            form: {
                name: '',
                date1: '',
                desc: '',
                items: [{
                    value: ''
                }]
            },

            butNext: true,
            display: [true, false, false],
        }
    },
    mounted() {
        
        if(this.active == 0){this.display[0] = true;}
    },
    methods: {

        next(){
            if (this.active++ > 2) this.active = 0;
            if (this.active == 0) {
                this.display[2] = false;
                this.display[0] = true;
            } else if (this.active == 1) {
                this.display[0] = false;
                this.display[1] = true;
            } else {
                this.display[1] = false;
                this.display[2] = true;
            }
        },

        addVoteItem(){
            var data = {
                Title: this.form.name,
                Statue: 1,
                Items: [],
                ItemsNum: [],
                UserName: this.UserName,
                StopTime: this.form.date1
            }
            for(var i = 0; i < this.form.items.length; i++){
                data.Items.push(this.form.items[i].value);
                data.ItemsNum.push(0);
            }
            console.log(data);
            this.axios.post(this.url + '/AddVote', data)
                .then((data) => {
                    console.log(data);
                    if(data.data > 0){
                        this.$message({
                            message: '成功发布本条投票消息！',
                            type: 'success'
                        });
                    }else {
                        this.$message({
                            message: '发布失败！！',
                            type: 'error'
                        });
                    }
                })
                .catch((err) => {

                })
        },

        removeDomain(item) {
            var index = this.form.items.indexOf(item)
            if (index !== -1) {
            this.form.items.splice(index, 1)
            }
        },
        addDomain() {
            this.form.items.push({
            value: '',
            key: Date.now()
            });
        },

        Publish(){
            this.active = 3;
            this.display[1] = false;
            this.display[2] = false;

            this.addVoteItem();
            
        }
    }
}
</script>

<style scoped>

</style>
