<template>
        <el-container style="width: 70%;margin:auto;margin-top: -50px;">
            <el-header style="border-bottom: 1px solid #ddd;">
                <span style="float:left;line-height: 60px;font-size: 22px; " @click="goToIndex">在线投票系统</span>
                
                <el-button type="primary" icon="el-icon-edit" size="mini" @click="goToAddVote" style="float: right; margin-top: 18px;">新建投票</el-button>
                
                <el-button plain size="mini" style="float: right;margin-right: 10px; margin-top: 18px;" @click="goUserItem">我的投票</el-button>
            </el-header>
            <el-main style="border: 1px solid #fff;">
                <router-view ></router-view>
            </el-main>
        </el-container>
</template>

<script>
export default {
    name: 'voteIndex',
    data () {
        return {
            title: '在线投票系统',
            chooseId: 0,
        }
    },
    methods: {
        goToAddVote(){
            this.$router.push('/home/addVoteItem');
        },
        goToIndex(){
            this.$router.push('/home/Index');
        },
        goToClick(data){
            this.chooseId = data;
        },
        changeId(data){
            this.changeId = data;
        }
        ,
        goUserItem(){
            this.$router.push('/home/useritem');
        }
    },
}
</script>
