/***********************
created by maoling@putao.com

封装oc接口

***********************/

#import "CustomIOSHelper.h"
#import <AssetsLibrary/AssetsLibrary.h>

#if defined(__cplusplus)
extern "C"{
#endif
    extern void CancelAllLocalNotifications();
    extern void ClearLocalNotifications();
    extern void SetStatusBarHiddenIOS(bool isHidden);
    
#if defined(__cplusplus)
}
#endif

@implementation CustomIOSHelper

#if defined(__cplusplus)
extern "C"{
#endif

    void CancelAllLocalNotifications()
    {
        NSLog(@"CancelAllLocalNotifications");
        [UIApplication sharedApplication].applicationIconBadgeNumber = 0;
        [[UIApplication sharedApplication] cancelAllLocalNotifications];
    }
 
    void ClearLocalNotifications()
    {
        NSLog(@"ClearLocalNotifications");
        [UIApplication sharedApplication].applicationIconBadgeNumber = 0;
        [UIApplication sharedApplication].scheduledLocalNotifications = [UIApplication sharedApplication].scheduledLocalNotifications;
    }

    void SetStatusBarHiddenIOS(bool isHidden)
    {
        [[UIApplication sharedApplication] setStatusBarHidden:isHidden withAnimation:YES];
    }
    
#if defined(__cplusplus)
}
#endif

@end
